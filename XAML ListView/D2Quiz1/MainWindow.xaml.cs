using System.Windows;
using WebUsers;

namespace D2Quiz1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var users = RandomUsers.GetUsers(15);



            lvUsers.ItemsSource = users;
        }
    }
}
