using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Dog : IAnnoying
    {
        public string Name { get; set; }
        public string Bark
        {
            get
            {
                return "Bark!";
            }
        }

        public Dog(string name)
        {
            Name = name;
        }

        public string Annoy()
        {
            return Bark;
        }
    }
}
