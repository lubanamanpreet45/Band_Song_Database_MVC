using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band_Song_Database_MVC.Models
{
    //Producer if the band 
    public class Producer
    {
        //Producer id
        public int Id { get; set; }

        //Producer name
        public string Name { get; set; }

        //Producer web site
        public string WebSite { get; set; }

    }
}
