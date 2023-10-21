using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDemo.CafeMenu
{
    public class Menu
    {
        //Menu Items

        public Product[] MenuItems { get;}

        public Menu(params Product[] menuItems)
        {
            this.MenuItems=menuItems;
            MenuItems = menuItems;
            
        }

        //indexer
        public Product? this[string ItemName]
        {
            get
            {
                return MenuItems.First(item=>item.Name == ItemName);
            }
        }




    }
}
