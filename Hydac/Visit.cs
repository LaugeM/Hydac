using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Visit
    {
        public string Date { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public bool SafetyFolder { get; set; }
        private int ItemCount = 1;
        public Visit(string date, string arrival, string departure, bool safetyFolder)
        {
            this.Date = date;
            this.Arrival = arrival;
            this.Departure = departure;
            this.SafetyFolder = safetyFolder;
        }

        private Guest[] Guests = new Guest[50];


        public void AddGuest(string firstName, string lastName, string company)
        {
            Guest gu = new Guest(firstName, lastName, company);
            this.Guests[ItemCount] = gu;
            this.ItemCount++;
        }
    }
}
