using Model.Connection;
using MySqlConnector;

namespace Model;

public class User
{
    public const string datadase = "v03_survey_Moon";

    public string First { get; set; }

    public string Last { get; set; }

    public string Sex { get; set; }

    public int Age { get; set; }

    public int Height { get; set; }

    public int? Id { get; private set; }

    public int Save()
    {
        using var dbConn = MariaDbConnection.GetConnection();
        dbConn.Open();

        using MySqlCommand cmdUseDb = new MySqlCommand($"USE {datadase}", dbConn);
        cmdUseDb.ExecuteNonQuery();

        using var q = new MySqlCommand("INSERT INTO `user` (`first`,`last`,age,sex,height) VALUES (@f,@l,@a,@s,@h)", dbConn);
        q.Parameters.AddWithValue("f", First);
        q.Parameters.AddWithValue("l", Last);
        q.Parameters.AddWithValue("a", Age);
        q.Parameters.AddWithValue("s", Sex);
        q.Parameters.AddWithValue("h", Height);

        q.ExecuteNonQuery();

        Id = (int)q.LastInsertedId;

        return Id ?? 0;

    }
}


