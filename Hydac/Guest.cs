using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Guest
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }
        public string ArrivalTime { get; set; }
        public bool SafetyfolderGiven { get; set; }



        public Guest(string firstName, string lastName, string company, string date, string arrivalTime, bool safetyfolderGiven)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Company = company;
            this.Date = date;
            this.ArrivalTime = arrivalTime;
            this.SafetyfolderGiven = safetyfolderGiven;
        }

        public string MakeTitle()
        {
            return $"{FirstName};{LastName};{Company};{Date};{ArrivalTime};{SafetyfolderGiven}";
        }
    }
}
