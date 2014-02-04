using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
