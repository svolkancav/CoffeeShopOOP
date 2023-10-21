using CafeDemo.CafeMenu;
using CafeDemo.CafeMenu.Extrass;
using CafeDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CafeDemo.CafeOrder
{
    public class OrderItems
    {
        public OrderItems(Product ıtem, CofeeSize size,params IExtra[] extras)
        {
            Item = ıtem;
            Size = size;
            this.Extras = extras;

            Price = Item.Price + (int)Size+ Extras.Sum(e=>e.Price);

            //foreach (var extra in extras)
            //{
            //    Price += extra.Price;
            //    PrepTime += extra.PrepTime;
            //}

            PrepTime = TimeSpan.FromSeconds(Item.PrepTime.TotalSeconds + (int)Size +Extras.Sum(e => e.PrepTime.TotalSeconds));
        }

        public Product Item { get;}
        public CofeeSize Size { get;}
        public IExtra[] Extras { get;}

        public decimal Price { get; }

        public TimeSpan PrepTime { get;}
    }
}
