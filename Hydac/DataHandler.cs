using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Hydac
{
    internal class DataHandler
    {
        private string _dataFileName;
        public string DataFileName { get => _dataFileName; }

        public DataHandler(string dataFileName)
        {
            _dataFileName = dataFileName;
        }

        public void SaveGuest(Guest guest)
        {
            try
            {

                using var writer = new StreamWriter(DataFileName);

                writer.WriteLine(guest.MakeTitle());
            }

            catch (Exception e)
            { Console.WriteLine($"Exeption {e.Message}"); }

        }


    }

}