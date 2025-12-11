using FP_C.API.Models.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace FP_C.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ClientInfo> Int_Clients { get; set; }
        public DbSet<PropertyInfo> Int_Properties { get; set; }
        public DbSet<VehicleInfo> Int_Vehicles { get; set; }
        public DbSet<PolicyInfo> Int_Policies { get; set; }
        public DbSet<AstuteRequest> Int_AstuteRequests { get; set; }
        public DbSet<Broker> Int_Broker { get; set; }
        public DbSet<BrokerRequest> Int_BrokerRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Properties)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Properties)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(p => p.Policies)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(v => v.Vehicles)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<ClientInfo>()
                .HasMany(b => b.BrokerRequests)
                .WithOne(c => c.ClientInfo)
                .HasForeignKey(c => c.ClientInfoId);
            modelBuilder.Entity<Broker>()
                .HasMany(b => b.BrokerRequests)
                .WithOne(b => b.Broker)
                .HasForeignKey(b => b.BrokerId);

                

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
