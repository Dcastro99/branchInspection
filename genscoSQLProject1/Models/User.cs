namespace genscoSQLProject1.Models
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mi { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int defaultLocationId { get; set; }
        public string companyId { get; set; }
        public int roleId { get; set; }
        public string createdByUserId { get; set; }
        public DateTime createdDate { get; set; }
        public string activeInd { get; set; }

    }
}
