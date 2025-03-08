using Microsoft.EntityFrameworkCore;

namespace MyPetsHealthHubApi.Data
{
    using global::MyPetsHealthHubApi.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<VetUser> VetUsers { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PetCard> PetCards { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<Grooming> Groomings { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ScheduledQuery> ScheduledQueries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vet>()
                .HasOne(v => v.VetUser)
                .WithMany()
                .HasForeignKey(v => v.VetUserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Wallet)
                .WithMany()
                .HasForeignKey(a => a.WalletId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Vet)
                .WithMany()
                .HasForeignKey(a => a.VetId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PetCard)
                .WithMany()
                .HasForeignKey(p => p.PetCardId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.AppUser)
                .WithMany()
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Vet)
                .WithMany()
                .HasForeignKey(p => p.VetId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.AppUser)
                .WithMany()
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScheduledQuery>()
                .HasOne(s => s.Vet)
                .WithMany()
                .HasForeignKey(s => s.VetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScheduledQuery>()
                .HasOne(s => s.Pet)
                .WithMany()
                .HasForeignKey(s => s.PetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}