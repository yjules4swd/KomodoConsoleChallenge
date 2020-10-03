using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    class Program
    {
        static void Main(string[] args)
        {
            Badges managebadges = new Badges();
            Console.WriteLine("Hello Security Admin. What would you like to do? Select the number that corresponds to the menu option and press enter.");
            Console.WriteLine("1.)Add a badge.\n2.)Update a badge.\n3.)List all badges.");
            int choice = int.Parse(Console.ReadLine());
            while (choice != 4)
            {

                switch (choice)
                {
                    case 1:
                        {
                            managebadges.createNewBadge();
                            break;
                        }
                    case 2:
                        {
                            managebadges.UpdateBadge();
                            break;
                        }
                    case 3:
                        {
                            managebadges.listAllBadges();
                            break;
                        }
                    case 4:
                        {

                            break;
                        }
                }
                Console.WriteLine("Hello Security Admin. What would you like to do? Select the number that corresponds to the menu option and press enter.");
                Console.WriteLine("1.)Add a badge.\n2.)Edit a badge.\n3.)List all badges.");
                choice = int.Parse(Console.ReadLine());
            }
            Console.ReadLine();
        }
    }
}
