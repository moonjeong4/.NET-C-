using System.Collections.Generic;

namespace D16FinalExam.Model
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public long ArtistId { get; set; }
        public string? Name { get; set; }

        public float TotalAlbums
        {
            get
            {
                float ta = 0;
                foreach (var a in Albums)
                {
                    ta = Albums.Count;
                }
                return ta;
            }
        }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
