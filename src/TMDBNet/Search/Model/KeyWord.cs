using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.Model
{
    public sealed class KeyWord
    {
        public int? Id { get; }
        public string Name { get; }

        public KeyWord(int? id, string name)
        {
            Id = id;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(KeyWord))
                return false;

            var keyword = (KeyWord)obj;

            return keyword.Id == Id &&
                string.Equals(keyword.Name, Name);
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
