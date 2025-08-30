using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int Order { get; set; }


        public int SongId { get; set; }
        public Song Song { get; set; }

        public int PlayListId {  get; set; }
        public PlayList PlayList { get; set; }
        

    }
}