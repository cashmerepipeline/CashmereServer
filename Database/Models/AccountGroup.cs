namespace CashmereServer.Database.Models
{
    public class AccountGroup
    {
        public int AccountId { get; set; }
        public Account Account{ get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}