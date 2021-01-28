using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Band_Song_Database_MVC.Models;

namespace Band_Song_Database_MVC.Data
{
    public class Band_Song_Database_DBContext : DbContext
    {
        public Band_Song_Database_DBContext (DbContextOptions<Band_Song_Database_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Band_Song_Database_MVC.Models.Album> Album { get; set; }

        public DbSet<Band_Song_Database_MVC.Models.MusicBand> MusicBand { get; set; }

        public DbSet<Band_Song_Database_MVC.Models.Producer> Producer { get; set; }

        public DbSet<Band_Song_Database_MVC.Models.Song> Song { get; set; }
    }
}
