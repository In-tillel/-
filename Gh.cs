using System;
using System.Collections.Generic;
using System.Text;

namespace тортики
{
    internal class Gh
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Fg> Buttons { get; set; }
        public Gh(string name, string type, List<Fg> gh)
        {
            Name = name;
            Type = type;
            Buttons = gh;
        }
    }
}
