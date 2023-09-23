using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WcfNetworkTestClient.ServiceReference1;

namespace WcfNetworkTestClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class MainWindow : Window, IService1Callback
    {
        Service1Client client;
        ObservableCollection<Cols> colsCollection = new ObservableCollection<Cols>();
        bool flag = true;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += OnlineTimer_Tick;
            timer.Start();
        }

        private void InitializeClient()
        {
            IService1Callback callback = this;
            InstanceContext context = new InstanceContext(callback);
            client = new Service1Client(context);
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;

        private void Border_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (flag)
            {
                WindowState = WindowState.Maximized;
                flag = false;
            }
            else
            {
                WindowState = WindowState.Normal;
                flag = true;
            }
        }

        public void SendSearchResult(Cols currentFoundResult)
        {
            try
            {
                colsCollection.Add(currentFoundResult);
            }
            catch
            {

            }
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeClient();

            client.UserLogIn(nicknameTextBox.Text, passwordTextBox.Text);
            nicknameTextBlock.Text = nicknameTextBox.Text;

            if (client.GetUser(nicknameTextBox.Text, passwordTextBox.Text) == true)
            {
                primaryMenu.Visibility = Visibility.Hidden;
                mainMenu.Visibility = Visibility.Visible;
                LoadTest();
            }
            else if (client.GetAdmin(nicknameTextBox.Text, passwordTextBox.Text) == true)
            {
                primaryMenu.Visibility = Visibility.Hidden;
                mainMenu.Visibility = Visibility.Visible;
                secondaryMenu.Visibility = Visibility.Visible;
                LoadTest();
            }
        }

        private async void LoadTest()
        {
            client.StopSearch();
            listView.ItemsSource = null;
            colsCollection.Clear();

            ListCollectionView listCollectionView = new ListCollectionView(colsCollection);
            listView.ItemsSource = listCollectionView;

            await client.SearchCallbackAsync();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeClient();

            try
            {
                client.UserSignUp(nicknameTextBox.Text, passwordTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Пользователь с таким прозвищем уже существует.");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();


        private void LogOutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            client.UserLogOut(nicknameTextBlock.Text);

            nicknameTextBlock.Text = null;
            nicknameTextBox.Text = null;
            passwordTextBox.Text = null;

            listView.ItemsSource = null;
            userListBox.ItemsSource = null;

            mainMenu.Visibility = Visibility.Hidden;
            secondaryMenu.Visibility = Visibility.Hidden;
            primaryMenu.Visibility = Visibility.Visible;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            client.UserLogOut(nicknameTextBlock.Text);
            Application.Current.Shutdown();
        }

        private void StartTestListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cols selectedItem = (Cols)listView.SelectedItem;

            TestWindow testWindow = new TestWindow
            {
                TestNameClient = selectedItem.TestName
            };
            if (testWindow.ShowDialog() == testWindow.DialogResult
                && testWindow.DialogResult == true)
                client.TestIsPassed(nicknameTextBlock.Text);
        }

        private async void ListUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            client.StopSearch();
            listView.ItemsSource = null;
            colsCollection.Clear();

            ListCollectionView listCollectionView = new ListCollectionView(colsCollection);
            listView.ItemsSource = listCollectionView;

            await client.SearchCallbackAsync();
        }

        private async void StopUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await client.StopSearchAsync();
            }
            catch
            {
                MessageBox.Show("Пустой список.");
            }
        }

        private void OnlineTimer_Tick(object sender, EventArgs e)
        {
            InitializeClient();

            try
            {
                string[] userList = client.GetUsersOnline();
                userListBox.ItemsSource = userList;
            }
            catch
            {

            }
        }

        private void userListBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.W)
                    client.UpdateAdminStatusTrue(userListBox.SelectedItem.ToString());

                if (e.Key == Key.S && userListBox.SelectedItem.ToString() != nicknameTextBox.Text)
                    client.UpdateAdminStatusFalse(userListBox.SelectedItem.ToString());
            }
            catch
            {

            }
        }

        private void CreateTestButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTestWindow createTestWindow = null;
            if (createTestWindow == null)
            {
                createTestWindow = new CreateTestWindow();
                createTestWindow.Show();
            }
            else createTestWindow.Activate();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show
                (
                "1. Список отображает пользователей, которые в данный момент находятся онлайн. " +
                "Выбрав пользователя и нажав клавишу W вы дадите ему админа, нажав клавишу S - отнимите. " +
                "У себя отнять админа не получится." +
                "\n2. Клавиши при создании теста:" +
                "\n    Escape - выход из окна;" +
                "\n    F1 - Добавить TextBox;" +
                "\n    F2 - Добавить RadioButton;" +
                "\n    Enter - Завершить создание теста." +
                "\n    В самом низу строка для названия вашего теста. (обязательно)"
                );
        }
    }
}
