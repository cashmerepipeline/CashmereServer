using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashmereServer.Database.Models
{
    public class Role:BaseEntity, IExtendData
    {   
        [Column(TypeName="jsonb")]
        public string ExtendData { get; set; }
    }
}