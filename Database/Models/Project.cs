using System;

namespace CashmereServer.Database.Models
{
    public class Project : BaseEntity
    {
        public int[] GroupIds { get; set; }
        public int[] TeamIds { get; set; }

        public int[] SequenceIds { get; set; }
        public int[] ShotIds { get; set; }
        public int[] AssetLibraryIds { get; set; }
    }
}