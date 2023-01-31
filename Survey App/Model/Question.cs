using Model.Connection;
using MySqlConnector;

namespace Model;

public class Question
{
    public const string datadase = "v03_survey_Moon";

    public string Text { get; set; }

    public int? Id { get; private set; }

    public static List<Question> List()
    {
        using var dbConn = MariaDbConnection.GetConnection();
        dbConn.Open();

        using MySqlCommand cmdUseDb = new MySqlCommand($"USE {datadase}", dbConn);
        cmdUseDb.ExecuteNonQuery();

        using var q = new MySqlCommand("select questionId, question from question", dbConn);

        using var result = q.ExecuteReader();

        var questions = new List<Question>();

        if (result != null)
        {
            while (result.Read())
            {
                questions.Add(new Question() { Text = result.GetString(1), Id = result.GetInt32(0) });
            }
            result.Close();
        }
        return questions;

    }
}
