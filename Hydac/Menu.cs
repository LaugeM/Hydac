using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Menu
    {
        public string Title;
        public Menu(string menuTitle)
        {
            this.Title = menuTitle;
        }
        private int ItemCount = 1;
        private MenuItem[] MenuItems = new MenuItem[10];



        public void AddMenuItem(string menuTitle)
        {
            MenuItem mi = new MenuItem($"{this.ItemCount}. {menuTitle}");
            this.MenuItems[ItemCount] = mi;
            this.ItemCount++;
        }

        public void Show()
        {
            Console.WriteLine(Title);
            Console.WriteLine("0. Tilbage");
            for (int i = 1; i < ItemCount; i++)
            {
                Console.WriteLine(MenuItems[i].Title);
            }
        }

        public int SelectMenuItem()
        {
            while (true)
            {
                int userSelection;
                bool selectionIsNumber = int.TryParse(Console.ReadLine(), out userSelection);
                if (selectionIsNumber && userSelection <= this.ItemCount - 1)
                {
                    return userSelection;
                }

                Console.WriteLine($"Vælg et tal mellem 1 og {this.ItemCount} eller afslut ved at vælge 0.");

            }
        }
    }
}
