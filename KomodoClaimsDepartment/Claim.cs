using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoClaims_Repository;
namespace KomodoConsoleChallenge
{
    class Claim
    {
        string claimId;
        string claimType;
        string description;
        string claimAmount;
        string dateOfIncident;
        string dateOfClaim;
        bool isValid; //If claim is made within 30 days of incident,it is valid, otherwise it is invalid.
        ClaimsRepository Claims = new ClaimsRepository();
        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\ClaimTable.accdb;");
        int queueLocation = 0;
        public Claim()
        {
            
                
            claimId = "1";
            claimType = "Car";
            description = "Vehicle accident on I-465.";
            claimAmount = "$400.00";
            dateOfIncident = "4/25/18";
            dateOfClaim = "4/27/18";
            isValid = true;
            string firstclaim = string.Format("{0} {1} {2} {3} {4} {5} {6}", claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
            CreateDataBase(claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid.ToString());
            Claims.queue.Add(firstclaim);
            claimId = "2";
            claimType = "Home";
            description = "House fire in kitchen.";
            claimAmount = "$4000.00";
            dateOfIncident = "4/11/18";
            dateOfClaim = "4/12/18";
            isValid = true;
            string secondclaim = string.Format("{0} {1} {2} {3} {4} {5} {6}", claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
            CreateDataBase(claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid.ToString());
            Claims.queue.Add(secondclaim);
            claimId = "3";
            claimType = "Theft";
            description = "Stolen pancakes.";
            claimAmount = "$4.00";
            dateOfIncident = "4/27/18";
            dateOfClaim = "6/01/18";
            isValid = false;
            string thirdclaim = string.Format("{0} {1} {2} {3} {4} {5} {6}", claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
            CreateDataBase(claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid.ToString());
            Claims.queue.Add(thirdclaim);
            Claims.queuearray[0] = firstclaim;
            Claims.queuearray[1] = secondclaim;
            Claims.queuearray[2] = thirdclaim;
            if ((File.Exists("ClaimTable.accdb")))//update database
            {
                Console.WriteLine("Do you want to delete the database?(y/n)");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    File.Delete("ClaimTable.accdb");
                }
            }
        }

        public void menu()
        {
            Console.WriteLine("Choose a menu item then press Enter:\n1. See all claims.\n2. Take care of next claim.\n3. Enter a new claim.");
            string useranswer = Console.ReadLine();
            while (useranswer != "4")
            {

                switch (useranswer)
                {
                    case "1":
                        {
                            Claims.ClearConsole();
                            foreach (string m in Claims.queue)
                            {
                                Console.WriteLine(m + "\n");
                            }
                            
                            break;
                        }
                    case "2":
                        {
                            Claims.ClearConsole();
                            shownextitem();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the claim ID");
                            claimId = Console.ReadLine();
                            Console.WriteLine("Enter the claim type");
                            claimType = Console.ReadLine();
                            Console.WriteLine("Enter description");
                            description = Console.ReadLine();
                            Console.WriteLine("Enter the claim amount");
                            claimAmount = Console.ReadLine();
                            Console.WriteLine("Enter the date of incident");
                            dateOfIncident = Console.ReadLine();
                            Console.WriteLine("Enter the date of claim");
                            dateOfClaim = Console.ReadLine();
                            isValid = checkdate();
                            string thirdclaim = string.Format("{0} {1} {2} {3} {4} {5} {6}", claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
                            Claims.queue.Add(thirdclaim);
                            break;
                        }
                    case "4":
                        {

                            break;
                        }
                }
                Console.WriteLine("Choose a menu item then press Enter:\n1. See all claims.\n2. Take care of next claim.\n3. Enter a new claim.");
                useranswer = Console.ReadLine();
            }
            

            
        }

        public void shownextitem()
        {
            if (queueLocation >= 3)
            {
                queueLocation = 0;
            }
            Console.WriteLine(Claims.queuearray[queueLocation]);
            queueLocation++;
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string answer = Console.ReadLine();
            if (answer=="y")
            {
                
            }
        }

        public bool checkdate()
        {
            int[] incident = new int[3];
            int[] claim = new int[3];
            string[] firststring = dateOfIncident.Split('/');
            string[] secondstring = dateOfClaim.Split('/');
            int a = 0;
            foreach(string m in firststring)
            {
                incident[a] = int.Parse(m);
                a++;
            }
            a = 0;

            foreach (string m in secondstring)
            {
                claim[a] = int.Parse(m);
                a++;
            }
            bool check = false;
            if(incident[0]==claim[0])
            {
                if (incident[2] == claim[2])
                {
                    check = true;
                }
            }                                                                                                      
            return check;
        }

        public void CreateDataBase(string CID, string CType, string CDescription, string CAmount, string CdateIncident, string CdateClaim, string CIsValid)
        {
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClaimTable.accdb;";
            
            if ((File.Exists("ClaimTable.accdb")))//update database
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect; 
                command.CommandText = "INSERT INTO Table1 (Claim_ID, Claim_Type, Description, Claim_Amount, Date_Of_Incident, Date_Of_Claim, Is_Valid_Claim) values('" + CID + "','" + CType + "','" + CDescription + "','" + CAmount + "','" + CdateIncident + "','" + CdateClaim + "','" + CIsValid + "')";
                command.ExecuteNonQuery();
                using (OleDbDataReader read = command.ExecuteReader())
                {
                     
                    while (read.Read())
                    {
                       
                        Console.WriteLine("{0}", read[" Claim_ID "].ToString());
                    }
                    
                }
                connect.Close();
                
            }
            else //Create the database.
            {
                var create = new ADOX.Catalog();
                create.Create(connect.ConnectionString);
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "CREATE TABLE Table1 (" +
                   "[Claim_ID] VARCHAR( 50 ) ," +
                    "[Claim_Type] VARCHAR( 50 ) ," +
                    "[Description] VARCHAR( 50 )," +
                    "[Claim_Amount] VARCHAR( 50 )," +
                    "[Date_Of_Incident] VARCHAR( 50 )," +
                    "[Date_Of_Claim] VARCHAR( 50 )," +
                    "[Is_Valid_Claim] VARCHAR( 50 ))";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Table1 (Claim_ID, Claim_Type, Description, Claim_Amount, Date_Of_Incident, Date_Of_Claim, Is_Valid_Claim) values('" + CID + "','" + CType + "','" + CDescription + "','" + CAmount + "','" + CdateIncident + "','" + CdateClaim + "','" + CIsValid + "')";
                command.ExecuteNonQuery();
                connect.Close();
                
                
            }
            
        }
    }
}
