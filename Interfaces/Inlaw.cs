using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Inlaw : IAnnoying, INamable
    {
        public string Name { get; set; }

        public Inlaw(string name)
        {
            Name = name;
        }

        public string Annoy()
        {
            return "I need help because I'm an insufficient human.";
        }
    }
}
