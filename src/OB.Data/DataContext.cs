using Microsoft.EntityFrameworkCore;
using OB.Data.Entities;

namespace OB.Data
{
    public class DataContext : DbContext
    {
        //-----------------------------------------------
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //--------------------------------------------------------------------------
        public DbSet<Registrant> Registrants { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<ElectionState> ElectionStates { get; set; }
        //--------------------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Registrant>().ToTable("Registrants", schema: "OB");
            modelBuilder.Entity<Machine>().ToTable("Machines", schema: "OB");
            modelBuilder.Entity<ElectionState>().ToTable("ElectionStates", schema: "OB");


        }
        //-----------------------------------------------
    }
}
