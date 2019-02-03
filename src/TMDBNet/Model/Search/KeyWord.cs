using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class KeyWord
    {
        public int Id { get; }
        public string Name { get; }

        public KeyWord(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
