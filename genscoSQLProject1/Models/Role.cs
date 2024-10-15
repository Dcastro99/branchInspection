namespace genscoSQLProject1.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; } = string.Empty;
        public int? CreatedByUserId { get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime DateLastMaintained { get; set; }
        public bool DeleteFlag { get; set; }

        //----------------Navigation Properties-----------------//
        public ICollection<User> Users { get; set; }  // Navigation property to Users
        public User? CreatedByUser { get; set; }  // The user who created the role
    }
}
