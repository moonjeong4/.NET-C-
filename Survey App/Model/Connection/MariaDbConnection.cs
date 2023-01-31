using MySqlConnector;

namespace Model.Connection;
public static class MariaDbConnection
{
    //public const string dbName = "v03_survey_Moon";

    public static MySqlConnection GetConnection()
    {
        MySqlConnection connection = new("Server=localhost;User ID=root;Password=xxxxxx");
        return connection;
    }
}
