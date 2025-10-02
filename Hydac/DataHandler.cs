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
                using var writer = new StreamWriter(DataFileName, append: true);
                writer.WriteLine(guest.MakeTitle());
            }

            catch (Exception e)
            { Console.WriteLine($"Exeption {e.Message}"); }

        }

        public int TotalLines()
        {
            try
            {
                using (StreamReader r = new StreamReader(DataFileName))
                {
                    int i = 0;
                    while (r.ReadLine() != null) { i++; }
                    return i;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        
        public Guest[] LoadList()
        {
            Guest[] savedGuests = new Guest[TotalLines()];
            using var reader = new StreamReader(DataFileName); // sikrer lukning ved fejl
            string input = reader.ReadLine();
            int guestNumber = 0;
            while (input != null)
            {
                string[] guestArray = input.Split(';');
                Guest readGuest = new(
                guestArray[0], guestArray[1], guestArray[2], DateTime.Parse(guestArray[3]), bool.Parse(guestArray[4]), guestArray[5]);

                savedGuests[guestNumber] = readGuest;
                guestNumber++;

                input = reader.ReadLine();

            }
            return savedGuests;
            
        }

    }

}