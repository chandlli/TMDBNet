using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.Model
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Company))
                return false;

            var company = (Company)obj;

            return company.Id == Id &&
                string.Equals(company.LogoPath, LogoPath) &&
                string.Equals(company.Name, Name);
        }
        public override int GetHashCode()
        {
            var hashCode = -1287721097;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LogoPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
