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

        private int visitCount = 1;
        private Visit[] Visits = new Visit[50];
        public void AddGuestsFromFile()
        {
            Array.Clear(Visits, 0, Visits.Length);
            visitCount = 1;
            DataHandler initialHandler = new("GuestList.txt");
            foreach (Visit v in initialHandler.LoadList())
            {
                Visits[visitCount] = v;
                visitCount++;
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

            AddVisit(inputFirstName, inputLastName, inputCompany, dateAndTime, _safetyfolderGiven, Initials);
            

        }

        public void AddVisit(string firstName, string lastName, string company, DateTime dateAndTime, bool safetyfolderGiven, string currentEmployee)
        {
            Visit vi = new Visit(firstName, lastName, company, dateAndTime, safetyfolderGiven, currentEmployee);
            DataHandler handler = new DataHandler("GuestList.txt");
            handler.SaveGuest(vi);
            this.Visits[visitCount] = vi;
            this.visitCount++;
        }

        public void Show()
        {
            Console.WriteLine("Gæsteliste:");
            Console.WriteLine("0. Tilbage");
            if (visitCount > 1)
            {
                for (int i = 1; i < visitCount; i++)
                {
                    Console.Write(
                        $"{i}. {Visits[i].FirstName} {Visits[i].LastName} Firma: {Visits[i].Company} Dato: {Visits[i].DateAndTime.ToString("dd/mm/yyyy")} Ankomst: {Visits[i].DateAndTime.ToString("HH:mm")} Ansvarlig for besøg: {Visits[i].ResponsibleEmployee} "
                        );
                    switch (Visits[i].SafetyfolderGiven) { case true: Console.WriteLine("Sikkerhedsfolder udleveret "); break; case false: Console.WriteLine("Sikkerhedsfolder ikke udleveret "); break; }
                }
                Console.WriteLine("Klik på en vilkårlig tast for at gå tilbage");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Der er ingen gæster registreret.");
                Console.WriteLine("Klik på en vilkårlig tast for at gå tilbage");
                Console.ReadLine();
            }


        }

        public int SelectMenuItem()
        {
            while (true)
            {
                int userSelection;
                bool selectionIsNumber = int.TryParse(Console.ReadLine(), out userSelection);
                if (selectionIsNumber && userSelection <= this.visitCount)
                {
                    return userSelection;
                }

                Console.WriteLine($"Vælg et tal mellem 1 og {this.visitCount} eller afslut ved at vælge 0.");

            }
        }
    }
}
