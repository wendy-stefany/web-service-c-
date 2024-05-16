using Microsoft.EntityFrameworkCore;
using WebService.Models;

namespace WebService.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public DbSet<catalumno> catalumno { get; set; }

        //Constructor
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options): base(options) { 
            
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
