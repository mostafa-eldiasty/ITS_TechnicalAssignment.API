using ITS_TechnicalAssignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITS_TechnicalAssignment.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}