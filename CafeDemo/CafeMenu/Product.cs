using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDemo.CafeMenu
{
    public class Product
    {
        public Product(string name, decimal price, TimeSpan prepTime)
        {
            Name = name;
            Price = price;
            PrepTime = prepTime;
        }

        // Menu Items
        public Product[] MenuItems { get; }
        public string Name { get;}
        public decimal Price { get;}
        public TimeSpan PrepTime { get;}

    }
}
