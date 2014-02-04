using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class InterfaceTests
    {
        [TestMethod]
        public void BeAnnoyed()
        {
            List<IAnnoying> annoyingThings = new List<IAnnoying>();
            annoyingThings.Add(new Dog("Fido"));
            annoyingThings.Add(new Dog("Leda"));
            annoyingThings.Add(new Human("Bob"));
            annoyingThings.Add(new Human("Ralph"));
            annoyingThings.Add(new Human("Phil"));
            annoyingThings.Add(new Inlaw("Dennis"));

            foreach (var annoyingThing in annoyingThings)
            {

                if (annoyingThing is INamable)
                {
                    Console.Write(((INamable)annoyingThing).Name + "  ");
                }

                Console.Write(annoyingThing.Annoy() + "\n");
            }
        }
    }
}
