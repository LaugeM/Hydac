namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast dine initialer");
            Employee currentEmployee = new Employee(Console.ReadLine());
            GuestList guestList = new GuestList("Gæsteliste", currentEmployee.Initials);
            Menu mainMenu = new Menu("Hovedmenu");

            mainMenu.AddMenuItem("Gæster");
            mainMenu.AddMenuItem("Take-Care status");

            bool mainStop = false;

            while (mainStop == false)
            {
                Console.Clear();
                mainMenu.Show();
                switch (mainMenu.SelectMenuItem())
                {
                    case 0:
                        mainStop = true;
                        break;
                    case 1:
                        Menu guestMenu = new Menu("Gæster");
                        guestMenu.AddMenuItem("Registrer gæst");
                        guestMenu.AddMenuItem("Se nuværende gæster");
                        bool regGuestStop = false;
                        while (regGuestStop == false)
                        {
                            Console.Clear();
                            guestMenu.Show();
                            switch (guestMenu.SelectMenuItem())
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
                                    guestList.AddGuestsFromFile();
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
