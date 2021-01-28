using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band_Song_Database_MVC.Models
{

    //Represents a song
    public class Song
    {
        //Song id
        public int Id { get; set; }

        //Song title 
        public string Title { get; set; }

        //Album id foreign  key
        public int AlbumId { get; set; }

        //Misic band id foreign key
        public int MusicBandId { get; set; }

        //Produer id foreign key
        public int ProducerId { get; set; }

        //Album link 
        public Album Album { get; set; }

        //Misic band link
        public MusicBand MusicBand { get; set; }

        //Producer link
        public Producer Producer { get; set; }
    }
}
