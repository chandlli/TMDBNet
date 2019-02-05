using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.Model
{
    public sealed class Collection
    {
        public int Id { get; }
        public string BackdropPath { get; }
        public string Name { get; }
        public string PosterPath { get; }

        public Collection(int id, string backdropPath, string name, string posterPath)
        {
            Id = id;
            BackdropPath = backdropPath;
            Name = name;
            PosterPath = posterPath;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Collection))
                return false;

            var collection = (Collection)obj;

            return string.Equals(collection.BackdropPath, BackdropPath) &&
                collection.Id == Id &&
                string.Equals(collection.Name, Name) &&
                string.Equals(collection.PosterPath, PosterPath);
        }

        public override int GetHashCode()
        {
            var hashCode = 1879448529;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BackdropPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PosterPath);
            return hashCode;
        }
    }
}
