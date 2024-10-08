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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchInspection> BranchInspections { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User and Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // BranchInspection and Category relationship
            modelBuilder.Entity<Category>()
                .HasOne(c => c.BranchInspection)
                .WithMany(bi => bi.Categories)
                .HasForeignKey(c => c.BranchInspectionId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Category and Asset relationship
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Category and ChecklistItem relationship
            modelBuilder.Entity<ChecklistItem>()
                .HasOne(ci => ci.Category)
                .WithMany(c => c.ChecklistItems)
                .HasForeignKey(ci => ci.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Category and Comments relationship
            modelBuilder.Entity<Comments>()
                .HasKey(co => co.CommentId); // Specify the primary key
            modelBuilder.Entity<Comments>()
                .HasOne(co => co.Category)
                .WithMany(c => c.Comments)
                .HasForeignKey(co => co.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Optional: Asset and ChecklistItem relationship (if needed)
            modelBuilder.Entity<ChecklistItem>()
                .HasOne(ci => ci.Asset)
                .WithMany(a => a.ChecklistItems)
                .HasForeignKey(ci => ci.AssetId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
        }



    }

}
