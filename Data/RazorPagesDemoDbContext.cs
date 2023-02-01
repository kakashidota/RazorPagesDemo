using Microsoft.EntityFrameworkCore;
using RazorDemos.Models.Domain;

namespace RazorDemos.Data
{
    public class RazorPagesDemoDbContext : DbContext
    {
        public RazorPagesDemoDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
