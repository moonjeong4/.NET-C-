using D5Lab3;
using D5Lab3.Model;
using System.Linq;
using System.Windows;

namespace D5lab3;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private lab3Context db = new lab3Context();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {


        var customers = db.Customers.Join(db.Menus, c => c.FavouriteItem, m => m.MenuId,
                (c, m) => new { Customer = c, Menu = m }).ToList();


        lvCustomers.ItemsSource = customers;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddCustomer ac = new();

        ac.ShowDialog();
    }

}
