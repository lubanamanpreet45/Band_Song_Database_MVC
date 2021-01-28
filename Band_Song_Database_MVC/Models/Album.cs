using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Band_Song_Database_MVC.Models
{

    // Represents an Album
    public class Album
    {
        //Album Id 
        public int Id { get; set; }

        //Album name
        public string AlbumName { get; set; }

        //Release date of the album
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
