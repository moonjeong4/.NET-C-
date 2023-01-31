using Model;
using Model.Connection;
using MySqlConnector;

namespace SQLassignment1;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    public const string datadase = "v03_survey_Moon";

    private List<Question> questions;

    private int qIndex = 0;

    private static uint numQuestions = 0;

    private User user;

    private void Form1_Load(object sender, EventArgs e)
    {
        button2.Enabled = false;
        CreatDatabase();
        questions = Question.List();
        ShowQuestion(qIndex);
    }
    private void ShowQuestion(int questionListIndex)
    {
        var q = questions[questionListIndex];
        lblQuestionNo.Text = q.Id.ToString();
        lblQuestionText.Text = q.Text;
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        ShowQuestion(++qIndex % questions.Count);
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
        qIndex = qIndex > 0 ? --qIndex % questions.Count : questions.Count - 1;
        //qIndex = qIndex > 0 ? qIndex - 1 : questions.Count - 1; // means = 0;
        ShowQuestion(qIndex);
    }
    public static void CreatDatabase()
    {
        using var dbConn = MariaDbConnection.GetConnection();
        dbConn.Open();

        using MySqlCommand creatDb = new($"CREATE DATABASE IF NOT EXISTS {datadase}", dbConn);
        creatDb.ExecuteNonQuery();

        using MySqlCommand cmdUseDb = new MySqlCommand($"USE {datadase}", dbConn);
        cmdUseDb.ExecuteNonQuery();

        using MySqlCommand creatTUser = new("CREATE TABLE IF NOT EXISTS `user` (userId INT UNSIGNED auto_increment NOT NULL,`first` varchar(100) NOT NULL,`last` varchar(100) NOT NULL,age INT UNSIGNED NOT NULL,`sex` varchar(100) NOT NULL,height FLOAT NOT NULL,CONSTRAINT user_pk PRIMARY KEY(userId))", dbConn);
        creatTUser.ExecuteNonQuery();

        using MySqlCommand creatTQuestion = new("CREATE TABLE IF NOT EXISTS question (questionId INT UNSIGNED auto_increment NOT NULL,question varchar(256) NOT NULL,CONSTRAINT question_pk PRIMARY KEY (questionId))", dbConn);
        creatTQuestion.ExecuteNonQuery();

        using MySqlCommand creatTAnswer = new($"CREATE TABLE IF NOT EXISTS answer (answerId INT UNSIGNED auto_increment NOT NULL,userId INT UNSIGNED NOT NULL,questionId INT UNSIGNED NOT NULL,answer INT UNSIGNED NOT NULL,CONSTRAINT answer_pk PRIMARY KEY (answerId),CONSTRAINT answer_FK FOREIGN KEY (userId) REFERENCES {datadase}.`user`(userId) ON DELETE RESTRICT ON UPDATE RESTRICT,CONSTRAINT answer_FK_1 FOREIGN KEY (questionId) REFERENCES {datadase}.question(questionId) ON DELETE RESTRICT ON UPDATE RESTRICT)", dbConn);
        creatTAnswer.ExecuteNonQuery();

        using MySqlCommand cmdNumQuestion = new MySqlCommand("select count(questionId) from question", dbConn);
        numQuestions = Convert.ToUInt32(cmdNumQuestion.ExecuteScalar());

        if (numQuestions == 0)
        {
            List<string> questions = new()
            {
                "How much do you like Java?",
                "How much do you like C#?",
                "How much do you like SQL?"
            };

            foreach (var q in questions)
            {
                using MySqlCommand insertQuestion = new MySqlCommand("INSERT INTO question (`question`) VALUES (@q)", dbConn);
                insertQuestion.Parameters.AddWithValue("q", q);
                insertQuestion.ExecuteNonQuery();
            }

            numQuestions = (uint)questions.Count;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        user = new User
        {
            First = textBox1.Text,
            Last = textBox2.Text,
            Age = int.Parse(textBox3.Text),
            Sex = textBox4.Text,
            Height = int.Parse(textBox5.Text)
        };

        user.Save();

        textBox1.Clear();
        textBox2.Clear();
        textBox3.Clear();
        textBox4.Clear();
        textBox5.Clear();

        button2.Enabled = true;
        button1.Enabled = false;

    }

    private void button2_Click(object sender, EventArgs e)
    {
        using var dbConn = MariaDbConnection.GetConnection();
        dbConn.Open();

        using MySqlCommand cmdUseDb = new MySqlCommand($"USE {datadase}", dbConn);
        cmdUseDb.ExecuteNonQuery();

        using var q1 = new MySqlCommand("insert into answer (`userId`,`questionId`,answer) values (@1,@2,@3);",
            dbConn);
        q1.Prepare();
        q1.Parameters.AddWithValue("1", user.Id);
        q1.Parameters.AddWithValue("2", questions[qIndex].Id);
        q1.Parameters.AddWithValue("3", int.Parse(textBox7.Text));


        q1.ExecuteScalar();


        textBox7.Clear();
    }
}