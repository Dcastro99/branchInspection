namespace genscoSQLProject1.Models
{
    public class User
    {
        public int UserId { get; set; }

        public  string FirstName { get; set; } = string.Empty;
        public  string LastName { get; set; } = string.Empty;
        public string? Mi { get; set; } 
        public  string Email { get; set; } = string.Empty;
        public  string Password { get; set; } = string.Empty;
        public string DefaultLocationId { get; set; } = string.Empty;
        public  string CompanyId { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Role? Role { get; set; } 
        public  string CreatedByUserId { get; set; } = string.Empty;
        public  DateTime CreatedDate { get; set; }
        public  string ActiveInd { get; set; } = string.Empty;
    }
}

