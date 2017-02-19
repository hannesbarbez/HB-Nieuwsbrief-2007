using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace HB_NieuwsbriefDatabaseConnection
{
    public class DataSource
    {
        private const string ERROR_CONNECTION = "ERROR_CONNECTION";
        private string connectionProperties, row, table;

        private MySqlConnection connection;
        private MySqlCommand command;

        public DataSource(string server, string database, string user, string password, string row, string table)
        {
            connectionProperties = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password + ";";
            this.row = row;
            this.table = table;
        }

        private string Query(string query)
        {
            //initial declaration is an errormessage in case response doesn't get filled with valuable data
            string receipients = ERROR_CONNECTION;
            try
            {
                command.CommandText = query;
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                receipients = "";
                foreach (DataRow row in table.Rows)
                {
                    object[] cells = row.ItemArray; //copy cells to receipients because all contain e-mail addresses.
                    foreach (object cell in cells) receipients += cell.ToString() + Environment.NewLine;
                }
                connection.Close();
                return receipients;
            }
            catch
            {
                return receipients;
            }
        }

        private bool MakeConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionProperties);
                command = connection.CreateCommand();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string[] StringToArray(string s)
        {
            if (!s.Equals(ERROR_CONNECTION))
            {
                return s.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }
            else return null;
        }

        public string[] GetRecipients()
        {
            MakeConnection();
            string s = Query("SELECT " + this.row + " mail FROM " + this.table);
            return StringToArray(s.ToLower());
        }
    }
}