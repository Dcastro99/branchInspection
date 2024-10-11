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
            // Asset -> Branch (Many-to-One)
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Assets)
                .HasForeignKey(a => a.BranchId);

            // AssetItems -> FormAssets (Many-to-One)
            modelBuilder.Entity<AssetItems>()
                .HasOne(ai => ai.FormAssets)
                .WithMany(fa => fa.AssetItems)
                .HasForeignKey(ai => ai.FormAssetsId);

            // AssetItems -> ChecklistItem (One-to-One)
            modelBuilder.Entity<AssetItems>()
                .HasOne(ai => ai.ChecklistItem)
                .WithOne(ci => ci.AssetItems)
                .HasForeignKey<AssetItems>(ai => ai.ChecklistItemId);

            // BranchInspection -> Branch (Many-to-One)
            modelBuilder.Entity<BranchInspection>()
                .HasOne(bi => bi.Branch)
                .WithMany(b => b.BranchInspections)
                .HasForeignKey(bi => bi.BranchId);

            // BranchInspection -> FormAssets (One-to-Many)
            modelBuilder.Entity<BranchInspection>()
                .HasMany(bi => bi.FormAssets)
                .WithOne(fa => fa.BranchInspection)
                .HasForeignKey(fa => fa.BranchInspectionId);

            // BranchInspection -> FormItems (One-to-Many)
            modelBuilder.Entity<BranchInspection>()
                .HasMany(bi => bi.FormItems)
                .WithOne(fi => fi.BranchInspection)
                .HasForeignKey(fi => fi.BranchInspectionId);

            // BranchInspection -> FormCategory (One-to-Many)
            modelBuilder.Entity<BranchInspection>()
                .HasMany(bi => bi.FormCategory)
                .WithOne(fc => fc.BranchInspection)
                .HasForeignKey(fc => fc.BranchInspectionId);

            // FormItems -> ChecklistItem (One-to-One)
            modelBuilder.Entity<FormItems>()
                .HasOne(fi => fi.ChecklistItem)
                .WithOne(ci => ci.FormItem)
                .HasForeignKey<FormItems>(fi => fi.ChecklistItemId);

            // FormCategory -> Category (One-to-One)
            modelBuilder.Entity<FormCategory>()
                .HasOne(fc => fc.Category)
                .WithOne(c => c.FormCategory)
                .HasForeignKey<FormCategory>(fc => fc.CategoryId);

            // User -> Role (Many-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }




    }

}
