namespace genscoSQLProject1.Dto
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; } = string.Empty;
        public int? CreatedByUserId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime DateLastMaintained { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
