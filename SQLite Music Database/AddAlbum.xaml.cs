using D16FinalExam.Model;
using System.Windows;

namespace D16FinalExam
{
    /// <summary>
    /// Interaction logic for AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Window
    {
        public event NotifyEventHandler Saved;

        public AddAlbum()
        {
            InitializeComponent();
        }
        private chinookContext db = new chinookContext();

        public Artist Artist { get; set; }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.Attach(Artist);

            var Album = new Album()
            {
                Title = tb1.Text,
                Artist = Artist
            };
            db.Albums.Add(Album);
            db.SaveChanges();
            Saved?.Invoke(this);
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
