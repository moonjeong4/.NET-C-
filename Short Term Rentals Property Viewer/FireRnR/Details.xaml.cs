using Model;
using System;
using System.Windows;

namespace View;

/// <summary>
/// Interaction logic for Details.xaml
/// </summary>
public partial class Details : Window
{
    public Details()
    {
        InitializeComponent();
    }
    private FireRnRContext fr = new FireRnRContext();
    public User User { get; set; }

    public Property Property { get; set; }
    public Address Address { get; set; }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //if (Property != null)
        //{
        //    fr.Attach(Property);
        //    dts.DataContext = Property;

        //}

        //if (User != null)
        //{
        //    fr.Attach(User);
        //}
        dts.DataContext = Property;

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Rating r1 = new()
        {
            //Property = Property,
            //User = User,
            PropertyId = Property.PropertyId,
            UserId = User.UserId,
            Stars = (uint)Convert.ToInt32(tb1.Text),
            Review = tb2.Text
        };
        fr.Ratings.Add(r1);
        fr.SaveChanges();
        Close();
    }
}
