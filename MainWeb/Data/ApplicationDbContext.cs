using MainWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MainWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Create a DBSet for the application

        public DbSet<Category> Categories { get; set; }
    }
}
