using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entities
{
    public class Song
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationInSeconds { get; set; } 
        public string FilePath { get; set; }


        public int GenresId { get; set; }
        public Genre Genres { get; set; }
        
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; }

        public ICollection<SongArtist> SongArtists { get; set; }




    }
}
