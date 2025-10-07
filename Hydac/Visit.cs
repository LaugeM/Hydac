using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Visit
    {

        private bool _safetyfolderGiven;
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool SafetyfolderGiven { get { return _safetyfolderGiven; } }
        public string ResponsibleEmployee { get; set; }



        public Visit(string firstName, string lastName, string company, DateTime dateAndTime, bool safetyfolderGiven, string responsibleEmployee)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Company = company;
            this.DateAndTime = dateAndTime;
            this._safetyfolderGiven = safetyfolderGiven;
            this.ResponsibleEmployee = responsibleEmployee;
        }

        public string MakeTitle()
        {
            return $"{FirstName};{LastName};{Company};{DateAndTime.ToString()};{SafetyfolderGiven};{ResponsibleEmployee}";
        }
    }
}
