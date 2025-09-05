using Microsoft.EntityFrameworkCore;
using StudentDetails.Models.Domain;

namespace StudentDetails.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
