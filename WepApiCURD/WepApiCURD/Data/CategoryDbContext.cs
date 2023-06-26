using Microsoft.EntityFrameworkCore;
using WepApiCURD.Models;

namespace WepApiCURD.Data
{
    public class CategoryDbContext:DbContext
    {
        public CategoryDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Category> categories { get; set; } 
    }
}
