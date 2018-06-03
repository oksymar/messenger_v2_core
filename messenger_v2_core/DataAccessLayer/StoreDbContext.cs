using messenger_v2_core.Models;
using Microsoft.EntityFrameworkCore;

namespace messenger_v2_core.DataAccessLayer
{
    public class StoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
            }
        }

        public DbSet<GlobalMsgModel> GlobalMsg { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlobalMsgModel>().ToTable("GlobalMsg");
        }
    }
}