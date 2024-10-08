namespace genscoSQLProject1.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public  string RoleDescription { get; set; } = string.Empty;
        public  string CreatedByUserId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime DateLastMaintained { get; set; }
        public  string DeleteFlag { get; set; } = string.Empty;

        public  ICollection<User> Users { get; set; }  // Navigation property to Users
    }
}
