using MySqlConnector;

namespace DataAdapterEx;

internal static class DatabaseConnection
{
    internal static MySqlConnection GetConnection()
    {
        var conn = new MySqlConnection("Server=localhost;User ID=root;password=xxxxxx;Database=WFlab6");
        conn.Open();
        return conn;
    }

}
