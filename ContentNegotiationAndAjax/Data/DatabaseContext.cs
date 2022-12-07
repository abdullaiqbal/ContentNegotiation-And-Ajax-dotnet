using ContentNegotiationAndAjax.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentNegotiationAndAjax.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        //public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        //public DbSet<ViewModelNew.Models.StudentCourse> StudentCourse { get; set; }
    }
}
