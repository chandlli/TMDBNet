using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
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
    }
}
