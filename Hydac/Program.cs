namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast dine initialer");
            string initialer = Console.ReadLine();
            GuestList guestList = new GuestList("Gæsteliste");
            Menu mainMenu = new Menu("Hovedmenu");

            mainMenu.AddMenuItem("Gæster");
            mainMenu.AddMenuItem("Take-Care status");

            bool mainStop = false;

            while (mainStop == false)
            {
                Console.Clear();
                Console.WriteLine("----------");
                mainMenu.Show();
                switch (mainMenu.SelectMenuItem())
                {
                    case 0:
                        mainStop = true;
                        break;
                    case 1:
                        Console.Clear();
                        Menu regGuestMenu = new Menu("Gæster");
                        regGuestMenu.AddMenuItem("Registrer gæst");
                        regGuestMenu.AddMenuItem("Se nuværende gæster");
                        bool regGuestStop = false;
                        while (regGuestStop == false)
                        {
                            Console.WriteLine("----------");
                            regGuestMenu.Show();
                            switch (regGuestMenu.SelectMenuItem())
                            {
                                case 0:
                                    regGuestStop = true;
                                    break;
                                case 1:
                                    Console.Clear();
                                    guestList.RegGuestMenu();
                                    break;
                                case 2:
                                    Console.Clear();
                                    guestList.Show();
                                    break;
                            }
                        }
                        break;
                }

            }
        }
    }
}
