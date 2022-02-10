using MySql.Data.MySqlClient;

namespace R_Keeper_Technical
{
    public class DB
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=rkepper");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
