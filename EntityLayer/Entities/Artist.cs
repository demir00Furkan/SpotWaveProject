using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ProfilePictureUrl { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<SongArtist> songArtists { get; set; }    

    }
}
