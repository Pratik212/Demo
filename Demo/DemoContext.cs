using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        public virtual DbSet<Camp> Camps { get; set; }
        
        public virtual DbSet<School>Schools { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camp>()
                .HasKey(c => new {c.Id});
            
            base.OnModelCreating(modelBuilder);
        }
    }
}