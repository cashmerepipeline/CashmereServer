namespace CashmereServer.Database.Models
{
    public interface IRole
    {
        int RoleId { get; set; }
        Role Role { get; set; }
    }
}