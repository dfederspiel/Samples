using System;
using System.Linq;

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
