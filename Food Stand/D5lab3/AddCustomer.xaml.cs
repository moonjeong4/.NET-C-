using D5Lab3.Model;
using System.Linq;
using System.Windows;

namespace D5Lab3;

/// <summary>
/// Interaction logic for AddCustomer.xaml
/// </summary>
public partial class AddCustomer : Window
{
    public AddCustomer()
    {
        InitializeComponent();
    }
    private lab3Context db = new();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (CbFavItem.SelectedItem != null && CbFavItem.SelectedItem is not Model.Menu)
        {
            CbFavItem.SelectedItem = null;
        }

        var Customer = new Customer()
        {
            FirstName = fname.Text,
            LastName = lname.Text,
            CustomerPhoto = PUrl.Text,
            FavouriteItemNavigation = CbFavItem.SelectedItem as Model.Menu,
        };
        db.Customers.Add(Customer);
        db.SaveChanges();
        Close();
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CbFavItem.ItemsSource = db.Menus.ToList();
    }
}
