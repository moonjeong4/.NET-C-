using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace View
{

    public class AmenityEnabled
    {
        public bool Enabled { get; set; } = false;
        public Amenity Amenity { get; set; }

    }
    /// <summary>
    /// Interaction logic for AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Window
    {
        public AddProperty()
        {
            InitializeComponent();
        }
        public User User { get; set; }

        private List<AmenityEnabled> amenities;

        private FireRnRContext fr = new FireRnRContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CbAddress.SelectedItem != null && CbAddress.SelectedItem is not Model.Address)
            {
                CbAddress.SelectedItem = null;
            }

            var Property = new Property()
            {
                Name = pname.Text,
                Description = des.Text,
                NumRooms = (uint)Convert.ToInt32(rn.Text),

                OwnerUserId = User.UserId,
                Address = CbAddress.SelectedItem as Model.Address,
            };
            fr.Properties.Add(Property);


            foreach (var ea in amenities)
            {
                if (ea.Enabled)
                {
                    fr.Attach(ea.Amenity);

                    fr.PropertyAmenities.Add(new PropertyAmenity() { Amenity = ea.Amenity, Property = Property });
                }
            }

            fr.SaveChanges();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbAddress.ItemsSource = fr.Addresses.ToList();
            amenities = new();
            foreach (var a in fr.Amenities.AsNoTracking().ToList())
            {
                amenities.Add(new AmenityEnabled() { Amenity = a });
            }

            LbAmenities.ItemsSource = amenities;
        }
    }
}
