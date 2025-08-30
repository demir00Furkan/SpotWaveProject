using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; }


    }
}
