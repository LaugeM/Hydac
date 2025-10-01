using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hydac
{
    internal class GuestList
    {
        public string Title;
        public GuestList(string menuTitle)
        {
            this.Title = menuTitle;
        }

        private int guestCount = 1;
        private Guest[] Guests = new Guest[50];

        public void RegGuestMenu()
        {
            Console.Clear();
            Console.WriteLine("Registrer besøg:");
            Console.Write("Skriv gæstens fornavn: "); string inputFirstName = Console.ReadLine();
            Console.Write("Skriv gæstens efternavn: "); string inputLastName = Console.ReadLine();
            Console.Write("Skriv gæstens firma: "); string inputCompany = Console.ReadLine();

            AddGuest(inputFirstName, inputLastName, inputCompany);

            /*
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            var time = dateAndTime.TimeOfDay;

            Console.WriteLine($"date: {dateAndTime.ToString("dd/mm/yyyy")}");
            Console.WriteLine($"time: {dateAndTime.ToString("HH:mm")}");
            */
        }

        public void AddGuest(string firstName, string lastName, string company)
        {
            Guest gu = new Guest(firstName, lastName, company);
            this.Guests[guestCount] = gu;
            this.guestCount++;
        }
        /*
        public void AddVisit(string date, string arrival, string departure, bool safetyFolder)
        {
            Visit vi = new Visit(date, arrival, departure, safetyFolder);
            this.visits[visitCount] = vi;
            this.visitCount++;
        }
*/
        public void Show()
        {
            Console.WriteLine("0. Tilbage");
            for (int i = 1; i < guestCount; i++)
            {
                Console.WriteLine(Guests[i].FirstName);
            }
        }

        public int SelectMenuItem()
        {
            while (true)
            {
                int userSelection;
                bool selectionIsNumber = int.TryParse(Console.ReadLine(), out userSelection);
                if (selectionIsNumber && userSelection <= this.guestCount)
                {
                    return userSelection;
                }

                Console.WriteLine($"Vælg et tal mellem 1 og {this.guestCount} eller afslut ved at vælge 0.");

            }
        }
    }
}
