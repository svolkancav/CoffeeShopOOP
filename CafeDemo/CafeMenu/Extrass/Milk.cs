using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDemo.CafeMenu.Extrass
{
    internal struct Milk : IExtra
    {
        public decimal Price => 2.0m;

        public TimeSpan PrepTime => TimeSpan.FromSeconds(2);
    }
}
