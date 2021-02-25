using OB.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace OB.Data.Data
{

    public class DataContext : DbContext
    {
        //-----------------------------------------------
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //--------------------------------------------------------------------------------

        public DbSet<Candidate> Candidates { get; set;}
        public DbSet<ElectionState> ElectionStates { get; set;}
        public DbSet<Machine> Machines { get; set;}
        public DbSet<Office> Offices { get; set;}
        public DbSet<Question> Questions { get; set;}
        public DbSet<Registrant> Registrants { get; set;}
        public DbSet<Role> Roles { get; set;}
        public DbSet<UserAccount> UserAccounts { get; set;}
        public DbSet<UserAccountRole> UserAccountRoles { get; set;}
        public DbSet<Vote> Votes { get; set;}

    }
}
