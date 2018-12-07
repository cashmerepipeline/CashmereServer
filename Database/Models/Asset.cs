using System;

namespace CashmereServer.Database.Models
{
    public class Asset : BaseEntity
    {
       
        public Tag[] Tags{get; set;}

        public Shot[] Shots { get; set; }
        public Assembly[] Assemblies{get; set;}
        public AssetLibrary[] AssetLibraries{get; set;}
        public Environment[] Environments { get; set; }
    }
}