using genscoSQLProject1.Models;

namespace genscoSQLProject1.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Mi { get; set; }
        public string? Email { get; set; }
        public string? Default_branch { get; set; }
        public string? Default_company { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? ActiveInd { get; set; }
        public int Contact_id { get; set; }
    }
}
