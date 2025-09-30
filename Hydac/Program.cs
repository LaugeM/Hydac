namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast dine initialer");
            string initialer = Console.ReadLine();
            Menu mainMenu = new Menu("Hovedmenu");

            mainMenu.AddMenuItem("Tilbage");
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
                        Menu guestMenu = new Menu("Gæstemenu");
                        guestMenu.AddMenuItem("Tilbage");
                        guestMenu.AddMenuItem("Registrer gæst");
                        guestMenu.AddMenuItem("Se nuværende gæster");
                        bool guestStop = false;
                        while (guestStop == false)
                        {
                            Console.WriteLine("----------");
                            guestMenu.Show();
                            switch (guestMenu.SelectMenuItem())
                            {
                                case 0:
                                    guestStop = true;
                                    break;
                                case 1:
                                    Console.WriteLine("Hej");
                                    break;
                            }
                        }
                        break;
                }

            }
        }
    }
}
