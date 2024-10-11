namespace genscoSQLProject1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public  string FirstName { get; set; } = string.Empty;
        public  string LastName { get; set; } = string.Empty;
        public string? Mi { get; set; } 
        public  string? Email { get; set; } 
        public  string? Password { get; set; } 
        public string? DefaultLocationId { get; set; } 
        public  string? CompanyId { get; set; } 
        public int? RoleId { get; set; }
        public  string? CreatedByUserId { get; set; } 
        public  DateTime? CreatedDate { get; set; }
        public  string? ActiveInd { get; set; } 
        public int EmployeeId { get; set; }


        //----------------Navigation Properties-----------------//
        public Role? Role { get; set; }
        public ICollection<BranchInspection> BranchInspections { get; set; }
    }
}

