namespace genscoSQLProject1.Dto
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; } = string.Empty;
        public string CreatedByUserId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime DateLastMaintained { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
