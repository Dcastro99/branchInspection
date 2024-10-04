namespace genscoSQLProject1.Models
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleDescription { get; set; }
        public string createdByUserId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime dateLastMaintained { get; set; }
        public string deleteFlag { get; set; }

    }
}
