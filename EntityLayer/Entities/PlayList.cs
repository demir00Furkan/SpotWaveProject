using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class PlayList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public AppUser AppUser { get; set; }


        public ICollection<PlaylistSong> playlistSongs { get; set; }

    }
}
