using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace WcfNetworkTestClient
{
    /// <summary>
    /// Логика взаимодействия для CreateTestWindow.xaml
    /// </summary>
    public partial class CreateTestWindow : Window
    {
        bool flag = true;
        int setRow = 0;
        int setColumn = 0;
        bool rowLimit = false;

        public CreateTestWindow()
        {
            InitializeComponent();
            ColumnDefinition cd0 = new ColumnDefinition();
            ColumnDefinition cd1 = new ColumnDefinition();
            ColumnDefinition cd2 = new ColumnDefinition();
            cd0.Width = new GridLength(100, GridUnitType.Star);
            cd1.Width = new GridLength(100, GridUnitType.Star);
            cd2.Width = new GridLength(100, GridUnitType.Star);
            grid.ColumnDefinitions.Add(cd0);
            grid.ColumnDefinitions.Add(cd1);
            grid.ColumnDefinitions.Add(cd2);
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Закрыть окно создания
            if (e.Key == Key.Escape) Hide();

            // Добавить TextBox
            if (e.Key == Key.F1)
            {
                if (setColumn == 1 || setColumn == 2)
                {
                    setColumn = 0;
                    setRow++;
                }

                RowDefinition rd = new RowDefinition();
                grid.RowDefinitions.Add(rd);

                TextBox tb = new TextBox();
                tb.TextWrapping = TextWrapping.Wrap;
                tb.FontSize = 14;
                tb.MinHeight = 80;
                Thickness t = new Thickness(10, 10, 10, 10);
                tb.Margin = t;

                Grid.SetColumn(tb, 0);
                Grid.SetColumnSpan(tb, 3);
                Grid.SetRow(tb, setRow);
                grid.Children.Add(tb);

                setRow++;
            }

            // Добавить RadioButton
            if (e.Key == Key.F2)
            {
                if (setColumn == 0) rowLimit = false;

                if (rowLimit == false)
                {
                    RowDefinition rd = new RowDefinition();
                    grid.RowDefinitions.Add(rd);
                    rowLimit = true;
                }

                StackPanel sp = new StackPanel();
                RadioButton rb = new RadioButton();
                TextBox tb = new TextBox();

                Thickness t = new Thickness(10, 10, 10, 10);
                rb.Margin = t;
                tb.Margin = t;

                sp.Children.Add(rb);
                sp.Children.Add(tb);
                Grid.SetColumn(sp, setColumn);
                Grid.SetRow(sp, setRow);
                grid.Children.Add(sp);

                if (setColumn != 2) setColumn++;
                else
                {
                    rowLimit = false;
                    setColumn = 0;
                    setRow++;
                }
            }

            // Завершить создание теста
            if (e.Key == Key.Enter)
            {
                if (testName.Text != "")
                {
                    FileStream fs = new FileStream(
                        $@"D:\VS projects\CourseProjectForDesktop\WcfNetworkTestService\WcfNetworkTestService\Tests\{testName.Text}.xaml",
                        FileMode.CreateNew);
                    XamlWriter.Save(grid, fs);
                    fs.Close();

                    Hide();
                }
                else MessageBox.Show("Напишите название теста.");
            }
        }
    }
}
