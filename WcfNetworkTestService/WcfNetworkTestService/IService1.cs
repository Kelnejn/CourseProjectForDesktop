using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfNetworkTestService
{
    public interface ICallback1
    {
        [OperationContract]
        void SendSearchResult(Cols currentFoundResult);
    }

    [ServiceContract(CallbackContract = typeof(ICallback1))]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(string))]
        void SearchCallback();

        [OperationContract]
        void StopSearch();

        [OperationContract]
        void UserLogIn(string userNickname, string password);

        [OperationContract]
        bool UserSignUp(string userNickname, string password);

        [OperationContract]
        void UserLogOut(string userNickname);

        [OperationContract]
        bool GetUser(string userNickname, string password);

        [OperationContract]
        bool GetAdmin(string userNickname, string password);

        [OperationContract]
        List<string> GetUsersOnline();

        [OperationContract]
        void UpdateAdminStatusTrue(string userNickname);

        [OperationContract]
        void UpdateAdminStatusFalse(string userNickname);

        [OperationContract]
        void TestIsPassed(string userNickname);
    }

    [DataContract]
    public class Cols
    {
        string testName;
        DateTime creationTime;

        [DataMember]
        public string TestName { get => testName; set => testName = value; }

        [DataMember]
        public DateTime CreationTime { get => creationTime; set => creationTime = value; }
    }
}
