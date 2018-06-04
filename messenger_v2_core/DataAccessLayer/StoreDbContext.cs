using messenger_v2_core.Models;
using Microsoft.EntityFrameworkCore;

namespace messenger_v2_core.DataAccessLayer
{
    public class StoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                if (optionsBuilder.IsConfigured == false)
                {
                    optionsBuilder.UseNpgsql(
                        "User ID=test;Password=test;Host=localhost;Port=5432;Database=Postgres;Pooling=true;");
                }

                base.OnConfiguring(optionsBuilder);
            }
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }


        public DbSet<GlobalMsgModel> GlobalMsg { get; set; }
    }
}