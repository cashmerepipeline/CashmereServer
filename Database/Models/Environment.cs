using System;

namespace CashmereServer.Database.Models
{
    public class Environment
    {
        public Asset[] Assets { get; set; }
        public Assembly Assemblies { get; set; }
        public Shot[] Shots { get; set; }
    }
}