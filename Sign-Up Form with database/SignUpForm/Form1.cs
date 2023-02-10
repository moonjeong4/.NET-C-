using DataAdapterEx;
using MySqlConnector;

namespace Lab3;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {

        using var q1 = new MySqlCommand("insert into signee (`first`,`last`,phone,email) values (@1,@2,@3,@4);",
            DatabaseConnection.GetConnection());
        q1.Prepare();
        q1.Parameters.AddWithValue("1", textBox1.Text.ToString());
        q1.Parameters.AddWithValue("2", textBox2.Text.ToString());
        q1.Parameters.AddWithValue("3", textBox3.Text.ToString());
        q1.Parameters.AddWithValue("4", textBox4.Text.ToString());

        q1.ExecuteScalar();


        textBox1.Clear();
        textBox2.Clear();
        textBox3.Clear();
        textBox4.Clear();

    }



    private void button2_Click(object sender, EventArgs e)
    {
        textBox1.Clear();
        textBox2.Clear();
        textBox3.Clear();
        textBox4.Clear();
    }



    private void Form1_Load(object sender, EventArgs e)
    {


        using var q2 = new MySqlCommand("select first, last, phone, email from signee", DatabaseConnection.GetConnection());
        q2.Prepare();
        using MySqlDataReader reader = q2.ExecuteReader();

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                listBox1.Items.Add(reader.GetName(i) + ": " + reader.GetValue(i));

            }

        }

    }
}
