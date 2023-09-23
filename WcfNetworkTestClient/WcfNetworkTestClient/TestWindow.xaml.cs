using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WcfNetworkTestClient
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        bool flag = true;
        public string TestNameClient { get; set; }

        public TestWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            FileStream fs = new FileStream(
                $@"D:\VS projects\CourseProjectForDesktop\WcfNetworkTestService\WcfNetworkTestService\Tests\{TestNameClient}",
                FileMode.Open);
            mainGrid = System.Windows.Markup.XamlReader.Load(fs) as Grid;
            grid.Children.Add(mainGrid);
            fs.Close();
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

        private void ExitButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        private void CompleteTestButton_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
