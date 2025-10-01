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
        public string Title { get; set; }
        public string Initials { get; set; }
        public GuestList(string menuTitle, string initials)
        {
            Title = menuTitle;
            Initials = initials;
        }

        private int guestCount = 1;
        private Guest[] Guests = new Guest[50];
        public void AddGuestsFromFile()
        {
            DataHandler initialHandler = new("GuestList.txt");
            foreach (Guest g in initialHandler.LoadList())
            {
                Guests[guestCount] = g;
                guestCount++;
            }
        }

        public void RegGuestMenu()
        {
            Console.Clear();
            Console.WriteLine("Registrer besøg:");
            Console.Write("Skriv gæstens fornavn: "); string inputFirstName = Console.ReadLine();
            Console.Write("Skriv gæstens efternavn: "); string inputLastName = Console.ReadLine();
            Console.Write("Skriv gæstens firma: "); string inputCompany = Console.ReadLine();
            Console.WriteLine("Har du udleveret sikkerhedsfolderen? \nTast J for JA og N for NEJ");

            bool _safetyfolderGiven = false;
            bool correctChoice = false;
            while (correctChoice == false)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "j":
                        _safetyfolderGiven = true;
                        correctChoice = true;
                        break;
                    case "n":
                        _safetyfolderGiven = false;
                        correctChoice = true;
                        break;
                    default:
                        Console.WriteLine("Vælg mellem J for JA og N for NEJ");
                        break;
                }
            }

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            var time = dateAndTime.TimeOfDay;

            Console.WriteLine($"date: {dateAndTime.ToString("dd/mm/yyyy")}");
            Console.WriteLine($"time: {dateAndTime.ToString("HH:mm")}");

            AddGuest(inputFirstName, inputLastName, inputCompany, dateAndTime, _safetyfolderGiven, Initials);
            

        }

        public void AddGuest(string firstName, string lastName, string company, DateTime dateAndTime, bool safetyfolderGiven, string responsibleEmployee)
        {
            Guest gu = new Guest(firstName, lastName, company, dateAndTime, safetyfolderGiven, responsibleEmployee);
            DataHandler handler = new DataHandler("GuestList.txt");
            handler.SaveGuest(gu);
            this.Guests[guestCount] = gu;
            this.guestCount++;
        }

        public void Show()
        {
            Console.WriteLine("Gæsteliste:");
            Console.WriteLine("0. Tilbage");
            for (int i = 1; i < guestCount; i++)
            {
                Console.Write(
                    $"{i}. {Guests[i].FirstName} {Guests[i].LastName} Firma: {Guests[i].Company} Dato: {Guests[i].DateAndTime.ToString("dd/mm/yyyy")} Ankomst: {Guests[i].DateAndTime.ToString("HH:mm")} Ansvarlig for besøg: {Guests[i].ResponsibleEmployee} "
                    );
                switch (Guests[i].SafetyfolderGiven) { case true: Console.WriteLine("Sikkerhedsfolder udleveret "); break; case false: Console.WriteLine("Sikkerhedsfolder ikke udleveret "); break; }
            }
            Console.WriteLine("Klik på en vilkårlig tast for at gå tilbage");
            Console.ReadLine();
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
