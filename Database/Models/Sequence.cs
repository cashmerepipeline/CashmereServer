using System;
using System.Collections.Generic;

namespace CashmereServer.Database.Models
{
    public class Sequence
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid[] ShotIds { get; set; }     
        public List<Guid> Shots { get; set; }
    }
}