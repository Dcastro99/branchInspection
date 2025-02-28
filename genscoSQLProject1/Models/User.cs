namespace genscoSQLProject1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Mi { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Default_branch { get; set; }
        public string? Default_company { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ActiveInd { get; set; }
        public int Contact_id { get; set; }

        //----------------Navigation Properties-----------------//
        public RoleModel? Role { get; set; }
        public ICollection<BranchInspection> BranchInspections { get; set; }
        public ICollection<RoleModel> CreatedRoles { get; set; }  // Roles created by this user
    }
}
