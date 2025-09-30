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

        public Guest(string firstName, string lastName, string company)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Company = company;
        }
    }
}
