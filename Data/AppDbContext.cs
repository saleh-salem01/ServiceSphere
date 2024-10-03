using Microsoft.EntityFrameworkCore;
using PlatformServices.Models;

namespace PlatformServices.Data
{
    //this class is responsble for communication between the app
    //and the database
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Platform> platforms { get; set; }
    }
}