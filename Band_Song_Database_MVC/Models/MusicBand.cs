using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band_Song_Database_MVC.Models
{ //The music band 
    public class MusicBand
    {
        //Music band id
        public int Id { get; set; }
        //Music band name 
        public string Name { get; set; }

        //Established year 
        public int Established { get; set; }

    }
}
