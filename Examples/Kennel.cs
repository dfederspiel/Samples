using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public interface IPet
    {
        string Name { get; set; }
    }

    public class Pet : IPet
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("{0} is a Pet", Name);
        }
    }

    public class Dog : Pet, IPet
    {
        public string Breed { get; set; }
        public override string ToString()
        {
            return String.Format("{0} is a {1} Dog", Name, Breed);
        }
    }

    public class Mongoose : IPet
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("{0} is a Mongoose", Name);
        }
    }

    public class Kennel
    {
        public IEnumerable<IPet> Names { get; set; }

        public Kennel()
        {

            Names = new List<IPet>() 
            { 
                new Pet() { Name = "Punky" }, 
                new Dog() { Name = "Leda", Breed="Shih Tzu" } ,
                new Mongoose() { Name = "Mongo" }
            };

        }

        public Func<IPet, bool> IsPet
        {
            get
            {
                return u => u is Pet;
            }
        }

        public Func<IPet, Pet> AsPet
        {
            get
            {
                return u => new Pet
                {
                    Name = u.Name
                };
            }
        }

        public Func<IPet, dynamic> AsDynamic
        {
            get
            {
                return u => new { Name = u.Name, Something = "Testing", SomethingElse = "David".ToCrazyString() };
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in Names)
            {
                sb.AppendLine(s.ToString());
            }

            return sb.ToString();
        }
    }
}
