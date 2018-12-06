namespace CashmereServer.Database.Models
{
    public class AccountTeam
    {
        public int AccountId { get; set; }
        public Account Account{ get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}