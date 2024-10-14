using Microsoft.EntityFrameworkCore;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetItems> AssetItems { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchInspection> BranchInspections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<FormAssets> FormAssets { get; set; }
        public DbSet<FormCategory> FormCategories { get; set; }
        public DbSet<FormItems> FormItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        //-----------ON MODEL CREATING METHOD------------//

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FormCategory
            modelBuilder.Entity<FormAssets>()
                .HasKey(fa => new { fa.AssetId, fa.BranchInspectionId });

            modelBuilder.Entity<FormAssets>()
                .HasOne(f => f.Assets)
                .WithMany(a => a.FormAssets)
                .HasForeignKey(f => f.AssetId);

            modelBuilder.Entity<FormAssets>()
                .HasOne(f => f.BranchInspection)
                .WithMany(b => b.FormAssets)
                .HasForeignKey(f => f.BranchInspectionId);

            // AssetItems setup (many-to-many between FormAssets and ChecklistItem)
            modelBuilder.Entity<AssetItems>()
                .HasKey(ai => new { ai.ChecklistItemId, ai.AssetId, ai.BranchInspectionId });

            modelBuilder.Entity<AssetItems>()
                .HasOne(ai => ai.FormAssets)
                .WithMany(fa => fa.AssetItems)
                .HasForeignKey(ai => new { ai.AssetId, ai.BranchInspectionId });

            modelBuilder.Entity<AssetItems>()
                .HasOne(ai => ai.ChecklistItem)
                .WithMany(ci => ci.AssetItems)
                .HasForeignKey(ai => ai.ChecklistItemId);


            // BranchInspection
            modelBuilder.Entity<BranchInspection>()
                .Ignore(bi => bi.ApprovedByUser);
        }





    }

}
