using _191_MOMENT_4.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace _191_MOMENT_4.Data
{
    public class AlbumLibraryContext : DbContext
    {
        //constructor
        //store in variable options
        public AlbumLibraryContext(DbContextOptions<AlbumLibraryContext> options) : base(options)
        {

        }

        //connect to model
        public DbSet<AlbumModel> AlbumLibrary { get; set; }
    }
}
