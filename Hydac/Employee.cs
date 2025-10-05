using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Employee
    {
        private string _initials;
        public string Initials { get { return _initials; } }

        public Employee(string initials)
        {
            this._initials = initials;
        }
    }
}
