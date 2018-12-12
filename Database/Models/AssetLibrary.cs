using System;

namespace CashmereServer.Database.Models
{
    public class AssetLibrary
    {
        public Tag[] Tags { get; set; }

        public Asset[] Assets { get; set; }
        public Assembly[] Assemblies { get; set; }
        public Environment Environments { get; set; }

        public Project[] Projects { get; set; }         
    }
}