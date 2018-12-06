using System;

namespace CashmereServer.Database.Models
{
    public class Assembly : IBaseEntity
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

        public Asset[] Assets { get; set; }
        public AssetLibrary AssetLibrary { get; set; }
        public Shot[] Shots { get; set; }
        public Environment Environments { get; set; }
    }
}