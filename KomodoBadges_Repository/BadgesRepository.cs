using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class BadgesRepository
    {
        public Dictionary<int, List<string>> Badges = new Dictionary<int, List<string>>();



        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\BadgesTable.accdb;");
        public string CreateDataBase(string CID, string CType)
        {
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BadgesTable.accdb;";
            string IsDataBaseCreated = connect.ConnectionString;
            if ((File.Exists("BadgesTable.accdb")))//update database
            {
                Console.WriteLine("Found");
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "INSERT INTO Table1 (Badge_Number, Door_Access) values('" + CID + "','" + CType + "')";

                connect.Close();
            }
            else if (!(File.Exists("BadgesTable.accdb")))//Create the database.
            {


                var create = new ADOX.Catalog();
                create.Create(connect.ConnectionString);
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "CREATE TABLE Table1 (" +
                   "[Badge_Number] VARCHAR( 50 ) ," +
                    "[Door_Access] VARCHAR( 50 ))";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Table1 (Badge_Number, Door_Access) values('" + CID + "','" + CType + "')";
                command.ExecuteNonQuery();
                connect.Close();


            }
            return IsDataBaseCreated;
        }

        public string ReadFromDataBase()
        {

            string Read = "read";
            if ((File.Exists("BadgesTable.accdb")))//update database
            {
                Console.WriteLine("Text from database:\n");
                string SelectString = "SELECT * FROM Table1";
                string Connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BadgesTable.accdb;";
                using (OleDbConnection connect = new OleDbConnection(Connection))
                {
                    OleDbCommand com = new OleDbCommand(SelectString, connect);
                    connect.Open();
                    using (OleDbDataReader read = com.ExecuteReader())
                    {

                        while (read.Read())
                        {
                            Console.WriteLine("Badge: {0},\nDoor Access: {1}\n\n", read["Badge_Number"].ToString(), read["Door_Access"].ToString());

                        }
                    }
                    connect.Close();
                }
            }
            return Read;
        }

        public string DeleteDataBase()
        {
            string Deleted = "deleted";
            if ((File.Exists("ClaimTable.accdb")))//update database
            {

                File.Delete("BadgesTable.accdb");

            }
            return Deleted;
        }
    }
}
