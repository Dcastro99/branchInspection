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
        //public DbSet<AssetItems> AssetItems { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchInspection> BranchInspections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FormNote> FormNotes { get; set; }

        //-----------ON MODEL CREATING METHOD------------//

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ChecklistItem>()
                .HasOne(ci => ci.Category)
                .WithMany(c => c.ChecklistItems)
                .HasForeignKey(ci => ci.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.BranchInspection)
                .WithMany(bi => bi.Categories)
                .HasForeignKey(c => c.BranchInspectionId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Role>()
                .HasOne(r => r.CreatedByUser)
                .WithMany(u => u.CreatedRoles)
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);


            // BranchInspection
            modelBuilder.Entity<BranchInspection>()
                .Ignore(bi => bi.ApprovedByUser);
        }





    }

}
