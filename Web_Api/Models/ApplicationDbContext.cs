using Microsoft.EntityFrameworkCore;

namespace Web_Api.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Student>  stu { get; set; }    
    }
}
