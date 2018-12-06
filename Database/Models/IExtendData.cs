using System.ComponentModel.DataAnnotations.Schema;

namespace CashmereServer.Database.Models
{
    public interface IExtendData
    {
        [Column(TypeName="jsonb")]
        string ExtendData { get; set; }
    }
}