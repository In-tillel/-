using System;
using System.Collections.Generic;
using System.Text;

namespace тортики
{
    internal class Fg
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Fg(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
