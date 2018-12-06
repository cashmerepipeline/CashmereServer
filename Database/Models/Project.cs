using System;

namespace CashmereServer.Database.Models
{
    public class Project
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreationTime { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string ExtendData { get; set; }
        public string Descriptions { get; set; }

        public int[] GroupIds{get; set;}
        public int[] TeamIds{get; set;}
        
        public int[] SequenceIds { get; set; }
        public int[] ShotIds { get; set; }
        public int[] AssetLibraryIds { get; set; }
    }
}