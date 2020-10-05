 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using KomodoBadges_Repository;
namespace KomodoBadges
{
    class Badges
    {
        int badgeId;
        List<string> doorname = new List<string>();
        //List<int> BadgeName = new List<int>();
        // string badgeName;
        int doorNumber = 0;
        string userresponse;
        public string response = "";
        BadgesRepository MyBadges = new BadgesRepository();

        public string _response
        {
            get
            {
                return response;
            }
            set
            {
                response = value;
            }
        }

        public Badges()
        {
            MyBadges.ReadFromDataBase();
            MyBadges.DeleteDataBase();
        }

        public void createNewBadge()
        {

            Console.WriteLine("What is the number on the badge?");
            badgeId = int.Parse(Console.ReadLine());
            Console.WriteLine("List a door that it needs access to.");
            string dooraccess = Console.ReadLine();

            doorname.Add(dooraccess);

            Console.WriteLine("Any other doors(y/n)?");
            response = Console.ReadLine();
            while (response != "n")
            {
                Console.WriteLine("List a door that it needs access to.");
                dooraccess = Console.ReadLine();

                doorname.Add(dooraccess);

                Console.WriteLine("Any other doors(y/n)?");
                response = Console.ReadLine();
            }
            if (response == "n")
            {
                string values = "";

                foreach (string m in doorname)
                {
                    values += m + ",";
                }

                MyBadges.Badges.Add(badgeId, doorname);
                MyBadges.CreateDataBase(badgeId.ToString(), values);
                listAllBadges();
                Console.WriteLine("return to main nenu.");
            }
        }

        public void listAllBadges()
        {
            foreach (var contents in MyBadges.Badges.Keys)
            {
                Console.Write("Badge Number : " + contents + " door access ");
                foreach (var listMember in MyBadges.Badges[contents])
                {
                    Console.Write(" " + listMember);
                    string value = listMember;

                }
            }
            Console.WriteLine();
            MyBadges.ReadFromDataBase();
        }

        public void UpdateBadge()
        {
            int count = 0;
            Console.WriteLine("\nWhat is the badge number to update?");
            userresponse = Console.ReadLine();
            string build = "";
            foreach (var myaccess in MyBadges.Badges.Keys)
            {
                foreach (var Listchild in MyBadges.Badges[myaccess])
                {
                    if (myaccess.ToString() == userresponse)
                    {
                        if (count > 0)
                        {
                            build += " & ";
                            build += Listchild;
                        }
                        else
                        {
                            build += Listchild;
                        }
                        count++;
                    }
                }
                if (myaccess.ToString() == userresponse)
                {
                    Console.WriteLine("Badge: " + myaccess + " has access to Door: " + build);
                }

            }
            Console.WriteLine("What would you like to do?\n1. Remove a door\n2. Add a door");
            int response = int.Parse(Console.ReadLine());
            switch (response)
            {
                case 1:
                    Console.WriteLine("Which door would you like to remove?");
                    string removedoor = Console.ReadLine();
                    int Id = int.Parse(userresponse);
                    MyBadges.Badges[Id].Remove(removedoor);
                    MyBadges.DeleteDataBase();
                    listAllBadges();



                    break;
                case 2:
                    Console.WriteLine("Which door would you like to add?");
                    int Id1 = int.Parse(userresponse);
                    string adddoor = Console.ReadLine();
                    MyBadges.Badges[Id1].Add(adddoor);
                    MyBadges.DeleteDataBase();
                    listAllBadges();
                    break;
            }
        }

        // Creating properties to be used outside the class
        public int _badgId
        {
            get
            {
                return badgeId;
            }
            set
            {
                badgeId = value;
            }
        }

        // Creating properties to be used outside the class


        public List<string> _doorname
        {
            get
            {
                return doorname;
            }
            set
            {
                doorname = value;
            }
        }
    }
}
