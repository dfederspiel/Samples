﻿using System;
using System.Linq;

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
