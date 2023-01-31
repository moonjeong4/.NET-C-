using Model;
using System.Linq;
using System.Windows;
using View;

namespace FireRnR;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private FireRnRContext fr = new FireRnRContext();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var users = fr.Users.ToList();

        lvUsers.ItemsSource = users;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddUser au = new();

        au.ShowDialog();
    }

    public void login()
    {
        if (lvUsers.SelectedItem is User u)
        {
            PropertyList pl = new()
            {
                User = u,
            };

            pl.ShowDialog();
        }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        login();
    }

    private void lvUsers_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        login();
    }
}
