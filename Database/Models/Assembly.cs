using System;

namespace CashmereServer.Database.Models
{
    public class Assembly : BaseEntity
    {
        public Asset[] Assets { get; set; }
        public AssetLibrary AssetLibrary { get; set; }
        public Shot[] Shots { get; set; }
        public Environment Environments { get; set; }
    }
}