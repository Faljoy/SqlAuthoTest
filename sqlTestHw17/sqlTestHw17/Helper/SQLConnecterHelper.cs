using System.Data;
using System.Data.SqlClient;

namespace sqlTestHw17
{
    public class SQLConnecterHelper
    {
        private SqlConnection _connection;
        public void ConnectDataBase()
        {
            _connection = new SqlConnection("Server = DESKTOP-8SKND86\\SQLEXPRESS; DataBase = DI;Integrated Security = true;");
            this._connection.Open();
        }

        public DataTable MakeQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (!query.StartsWith("SELECT")) return null;
            return table;
        }
        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}