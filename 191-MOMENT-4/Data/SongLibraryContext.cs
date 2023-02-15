using _191_MOMENT_4.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace _191_MOMENT_4.Data
{
    public class SongLibraryContext : DbContext
    {
        //constructor
        //store in variable options
        public SongLibraryContext(DbContextOptions<SongLibraryContext> options) : base(options)
        {

        }

        //connect to model
        public DbSet<SongModel> SongLibrary { get; set; }
    }
}
