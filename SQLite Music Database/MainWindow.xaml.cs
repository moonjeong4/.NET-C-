using D16FinalExam.Model;
using System.Linq;
using System.Windows;

namespace D16FinalExam;

public delegate void NotifyEventHandler(object sender);

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private chinookContext db = new chinookContext();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var artists = db.Artists.ToList();
        lvArtists.ItemsSource = artists;

        na.IsEnabled = false;
    }

    private void lvArtists_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (lvArtists.SelectedItem is Artist a)
        {
            var albums = db.Albums.Where(a1 => a1.Artist == a).ToList();
            lvAlbums.ItemsSource = albums;

            na.IsEnabled = true;
        }
    }

    private void na_Click(object sender, RoutedEventArgs e)
    {
        AddAlbum ad = new()

        {
            Artist = (Artist)lvArtists.SelectedItem

        };
        ad.Saved += Ad_Saved;

        ad.ShowDialog();

    }

    private void Ad_Saved(object sender)
    {
        lvArtists.Items.Refresh();
    }

    private void lvAlbums_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (lvAlbums.SelectedItem is Album a)
        {
            var tracks = db.Tracks.Where(a1 => a1.Album == a).ToList();
            lvTracks.ItemsSource = tracks;
        }
    }
}
