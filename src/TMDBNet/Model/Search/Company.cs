using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class Company
    {
        public int Id { get; }
        public string LogoPath { get; }
        public string Name { get; }

        public Company(int id, string logoPath, string name)
        {
            Id = id;
            LogoPath = logoPath;
            Name = name;
        }
    }
}
