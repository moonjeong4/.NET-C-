using Model;
using System.Linq;
using System.Windows;

namespace View
{
    //public class PropertyRating
    //{
    //    public Property Property { get; set; }
    //    public Rating Rating { get; set; }
    //}

    /// <summary>
    /// Interaction logic for PropertyList.xaml
    /// </summary>
    public partial class PropertyList : Window
    {
        private FireRnRContext fr = new FireRnRContext();

        public User User { get; set; }

        public PropertyList()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (User != null)
            {
                login.DataContext = User;
            }

            var properties = fr.Properties.ToList();

            lvProperties.ItemsSource = properties;
        }

        private void ChkPool_Click(object sender, RoutedEventArgs e)
        {
            FilterAmenities();
        }

        private void ChkParking_Click(object sender, RoutedEventArgs e)
        {
            FilterAmenities();
        }

        private void FilterAmenities()
        {
            bool pl = ChkPool.IsChecked ?? false;
            bool pk = ChkParking.IsChecked ?? false;


            var q = fr.Properties.Where(p => true);
            if (pl)
            {
                var pas = fr.PropertyAmenities.Where(pa => pa.Amenity.Name == "pool");
                q = q.Where(p => pas.Where(pa => pa.Property == p).Any());
            }
            if (pk)
            {
                var pas = fr.PropertyAmenities.Where(pa => pa.Amenity.Name == "parking");
                q = q.Where(p => pas.Where(pa => pa.Property == p).Any());
            }

            lvProperties.ItemsSource = q.ToList();
        }

        private void lvProperties_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (lvProperties.SelectedItem is PropertyRating pr)
            //{
            //    Details d = new()
            //    {
            //        Property = pr.Property,
            //    };

            //    d.ShowDialog();
            //}
            if (lvProperties.SelectedItem is Property p)
            {
                Details d = new()
                {
                    Property = p,
                    User = User
                };

                d.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProperty ap = new()
            {
                User = User
            };

            ap.ShowDialog();
        }
    }
}
