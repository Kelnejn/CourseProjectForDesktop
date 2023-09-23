using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace WcfNetworkTestService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        List<Cols> colsList = new List<Cols>();
        bool searchCancel = false;
        ICallback1 clientCallback = null;
        DbNetworkTestServiceEntities context = new DbNetworkTestServiceEntities();

        private void Search()
        {
            string path = @"D:\VS projects\CourseProjectForDesktop\WcfNetworkTestService\WcfNetworkTestService\Tests";
            string mask = "*.xaml";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                if (directoryInfo.Exists && !searchCancel)
                {
                    FileInfo[] fileInfos = directoryInfo.GetFiles(mask);
                    foreach (FileInfo current in fileInfos)
                    {
                        Cols cols = new Cols()
                        {
                            TestName = current.Name,
                            CreationTime = current.CreationTime
                        };

                        colsList.Add(cols);
                        clientCallback?.SendSearchResult(cols);
                    }

                    DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                    foreach (DirectoryInfo current in directoryInfos)
                    {
                        if (!searchCancel)
                            Search();
                    }
                }
            }
            catch
            {

            }
        }

        public async void SearchCallback()
        {
            if (colsList == null) throw new FaultException<string>("Список данных для столбцов пуст.");
            clientCallback = OperationContext.Current.GetCallbackChannel<ICallback1>();
            searchCancel = false;
            await Task.Run(() => Search());
        }

        public void StopSearch() => searchCancel = true;

        public void UserLogIn(string userNickname, string password)
        {
            try
            {
                User selectedUser = (from t in context.Users
                                     where t.Nickname == userNickname
                                     && t.Password == password
                                     select t).First();

                selectedUser.OnlineStatus = true;
                context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Проверти правильность написания прозвища или пароля.");
            }
        }

        public bool UserSignUp(string userNickname, string password)
        {
            try
            {
                User user = new User()
                {
                    Nickname = userNickname,
                    Password = password,
                    NumOfTestsPassed = 0,
                    OnlineStatus = false,
                    AdminStatus = false,
                    RegistrationDate = DateTime.Now
                };

                if (userNickname.Length > 16 || userNickname.Length < 4
                    || password.Length > 32 || password.Length < 6)
                    MessageBox.Show("Проверти кол-во символов в прозвище или пароле.");
                else
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.InnerException?.ToString());
            }

            return true;
        }

        public void UserLogOut(string userNickname)
        {
            try
            {
                User selectedUser = (from t in context.Users
                                     where t.Nickname == userNickname
                                     select t).First();

                selectedUser.OnlineStatus = false;
                context.SaveChanges();
            }
            catch
            {

            }
        }

        public bool GetUser(string userNickname, string password)
        {
            var selectedUser = from t in context.Users
                               where t.AdminStatus == false
                               select t.Nickname;

            var selectedPassword = from t in context.Users
                                   where t.AdminStatus == false
                                   select t.Password;

            List<string> users = new List<string>(selectedUser);
            List<string> passwords = new List<string>(selectedPassword);

            if (users.Any(userNickname.Contains)
                && passwords.Any(password.Contains)) return true;
            else return false;
        }

        public bool GetAdmin(string userNickname, string password)
        {
            var selectedUser = from t in context.Users
                               where t.AdminStatus == true
                               select t.Nickname;

            var selectedPassword = from t in context.Users
                                   where t.AdminStatus == true
                                   select t.Password;

            List<string> users = new List<string>(selectedUser);
            List<string> passwords = new List<string>(selectedPassword);

            if (users.Any(userNickname.Contains)
                && passwords.Any(password.Contains)) return true;
            else return false;
        }

        public List<string> GetUsersOnline()
        {
            var result = from t in context.Users
                         where t.OnlineStatus == true
                         select t.Nickname;

            return new List<string>(result);
        }

        public void UpdateAdminStatusTrue(string userNickname)
        {
            try
            {
                User selectedUser = (from t in context.Users
                                     where t.Nickname == userNickname
                                     select t).First();

                selectedUser.AdminStatus = true;
                context.SaveChanges();
            }
            catch
            {

            }
        }

        public void UpdateAdminStatusFalse(string userNickname)
        {
            try
            {
                User selectedUser = (from t in context.Users
                                     where t.Nickname == userNickname
                                     select t).First();

                selectedUser.AdminStatus = false;
                context.SaveChanges();
            }
            catch
            {

            }
        }

        public void TestIsPassed(string userNickname)
        {
            try
            {
                User result = (from t in context.Users
                               where t.Nickname == userNickname
                               select t).First();

                result.NumOfTestsPassed++;
                context.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
