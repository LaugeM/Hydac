using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class GuestList
    {
        public string Title;
        public GuestList(string menuTitle)
        {
            this.Title = menuTitle;
        }
        private int ItemCount = 1;
        private Visit[] Visits = new Visit[50];



        public void AddVisit(string date, string arrival, string departure, bool safetyFolder)
        {
            Visit vi = new Visit(date, arrival, departure, safetyFolder);
            this.Visits[ItemCount] = vi;
            this.ItemCount++;
        }

        public void Show()
        {
            Console.WriteLine("0. Tilbage");
            for (int i = 1; i < ItemCount; i++)
            {
                //Console.WriteLine(Visits[i].firstName);
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

                Console.WriteLine($"Vælg et tal mellem 1 og {this.ItemCount - 1} eller afslut ved at vælge 0.");

            }
        }
    }
}
