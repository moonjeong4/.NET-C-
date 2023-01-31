using Model;
using System.Linq;
using System.Windows;

namespace View;

/// <summary>
/// Interaction logic for AddUser.xaml
/// </summary>
public partial class AddUser : Window
{
    public AddUser()
    {
        InitializeComponent();
    }
    private FireRnRContext fr = new();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (CbAddress.SelectedItem != null && CbAddress.SelectedItem is not Model.Address)
        {
            CbAddress.SelectedItem = null;
        }

        var User = new User()
        {
            First = fname.Text,
            Last = lname.Text,
            UserName = uname.Text,
            Email = uemail.Text,
            ImageFile = PUrl.Text,
            LastLogin = System.DateTime.Now,
            Joined = System.DateTime.Now,
            Address = CbAddress.SelectedItem as Model.Address,
        };
        fr.Users.Add(User);
        fr.SaveChanges();
        Close();

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CbAddress.ItemsSource = fr.Addresses.ToList();
    }
}
