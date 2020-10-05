using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class CafeRepository
    {
        public const int _SIZE = 5;
        public string[] _MenuItems = new string[_SIZE];
        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\CafeTable.accdb;");
        public string CreateDataBase(string CID, string CType, string CDescription, string CAmount, string CdateIncident)
        {
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CafeTable.accdb;";
            string IsDataBaseCreated = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CafeTable.accdb;";
            if ((File.Exists("CafeTable.accdb")))//update database
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "INSERT INTO Table1 (Meal_Number, Meal_Name, Meal_Description, Meal_Ingredients, Meal_Price) values('" + CID + "','" + CType + "','" + CDescription + "','" + CAmount + "','" + CdateIncident + "')"; command.ExecuteNonQuery();
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
                   "[Meal_Number] VARCHAR( 50 ) ," +
                    "[Meal_Name] VARCHAR( 50 ) ," +
                    "[Meal_Description] VARCHAR( 50 )," +
                    "[Meal_Ingredients] VARCHAR( 50 )," +
                    "[Meal_Price] VARCHAR( 50 ))";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Table1 (Meal_Number, Meal_Name, Meal_Description, Meal_Ingredients, Meal_Price) values('" + CID + "','" + CType + "','" + CDescription + "','" + CAmount + "','" + CdateIncident + "')";
                command.ExecuteNonQuery();
                connect.Close();


            }
            return IsDataBaseCreated;
        }

        public string ReadFromDataBase()
        {
            string ReadFrom = "read";
            if ((File.Exists("CafeTable.accdb")))//update database
            {
                Console.WriteLine("Text from database:\n");
                string SelectString = "SELECT * FROM Table1";
                string Connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CafeTable.accdb;";
                using (OleDbConnection connect = new OleDbConnection(Connection))
                {
                    OleDbCommand com = new OleDbCommand(SelectString, connect);
                    connect.Open();
                    using (OleDbDataReader read = com.ExecuteReader())
                    {

                        while (read.Read())
                        {
                            Console.WriteLine("Meal_Number: {0},\nMeal_Name: {1},\nMeal_Description: {2}\nMeal_Ingredients: {3}\nMeal_Price: {4}\n\n", read["Meal_Number"].ToString(), read["Meal_Name"].ToString(), read["Meal_Description"].ToString(), read["Meal_Ingredients"].ToString(), read["Meal_Price"].ToString());

                        }
                    }
                }
            }
            return ReadFrom;
        }

        public string DeleteDataBase()
        {
            string Deleted = "deleted";
            if ((File.Exists("CafeTable.accdb")))//update database
            {

                File.Delete("CafeTable.accdb");

            }
            return Deleted;
        }
    }
}
