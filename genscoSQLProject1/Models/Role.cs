namespace genscoSQLProject1.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
        public int? CreatedByUserId { get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime DateLastMaintained { get; set; }
        public bool Delete_Flag { get; set; }

        //---------NAVIGATION PROPERTIES-----------//
        public ICollection<User> Users { get; set; }  
        public User? CreatedByUser { get; set; }  
    }
}
