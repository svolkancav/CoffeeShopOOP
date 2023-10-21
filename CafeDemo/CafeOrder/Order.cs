using CafeDemo.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDemo.CafeOrder
{
    public class Order
    {
        public OrderItems[] Items { get;}
        public readonly Customer Owner;

        public Order(Customer owner, params OrderItems[] ıtems)
        {
            Items = ıtems;
            Owner = owner;
        }

        //public decimal TotalPrices()     // alttaki ile aynı şey
        //{
        //    decimal total = 0;

        //    foreach (var item in Items)
        //    {
        //        total += item.Price;
        //    }
        //    return total;
        //}


        public decimal TotalPrice => Items.Sum(x => x.Price);
        public TimeSpan TotalPrepTime => TimeSpan.FromSeconds(Items.Sum(x=>x.PrepTime.TotalSeconds));


    }
}
