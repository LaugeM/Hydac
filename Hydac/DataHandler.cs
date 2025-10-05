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

        public void SaveGuest(Visit visit)
        {
            try
            {
                using var writer = new StreamWriter(DataFileName, append: true);
                writer.WriteLine(visit.MakeTitle());
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
        
        public Visit[] LoadList()
        {
            if (TotalLines() > 0)
            {
                Visit[] savedVisits = new Visit[TotalLines()];
                StreamReader reader = new StreamReader(DataFileName);
                //using var reader = new StreamReader(DataFileName); // sikrer lukning ved fejl
                string input = reader.ReadLine();
                int guestNumber = 0;
                while (input != null)
                {
                    string[] visitArray = input.Split(';');
                    Visit readGuest = new(
                    visitArray[0], visitArray[1], visitArray[2], DateTime.Parse(visitArray[3]), bool.Parse(visitArray[4]), visitArray[5]);

                    savedVisits[guestNumber] = readGuest;
                    guestNumber++;

                    input = reader.ReadLine();

                }
                reader.Close();
                return savedVisits;
            }
            else
            {
                return Array.Empty<Visit>();
            }


        }

    }

}