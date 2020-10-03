using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoConsoleChallenge
{
    public class Program
    {
       public static void Main()
        {
            Menu RestaurantMenu = new Menu();
            string choice = "";
            Console.WriteLine("Press 1 to show the items on the menu.\nPress 2 to add an item to the menu.\nPress 3 to delete an item from the menu.\nPress 4 to close the program.");
            choice = Console.ReadLine();
            while (choice!="4")
            {
                
                switch (choice)
                {
                    case "1":
                        {
                            RestaurantMenu.populatemenu();
                            break;
                        }
                    case "2":
                        {
                            RestaurantMenu.add();
                            break;
                        }
                    case "3":
                        {
                            RestaurantMenu.delete();
                            break;
                        }
                    case "4":
                        {

                            break;
                        }
                }
                Console.WriteLine("Press 1 to show the items on the menu.\nPress 2 to add an item to the menu.\nPress 3 to delete an item from the menu.\nPress 4 to close the program.");
                choice = Console.ReadLine();
            }
           
            
        }
    }
}
