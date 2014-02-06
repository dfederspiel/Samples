using System;
using System.Linq;

namespace Interfaces
{
    public class Human : IAnnoying
    {
        public string Name { get; set; }

        public string Talk
        {
            get
            {
                return "Blah!";
            }
        }

        public Human(string name)
        {
            Name = name;
        }

        public string Annoy()
        {
            return Talk;
        }
    }
}
