using Model.Connection;
using MySqlConnector;

namespace Result
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const string datadase = "v03_survey_Moon";

        //private DataTable dataTable;
        //private MySqlDataAdapter dataAdapter;

        private void Form1_Load(object sender, EventArgs e)
        {

            using var dbConn = MariaDbConnection.GetConnection();
            dbConn.Open();

            using MySqlCommand cmdUseDb = new MySqlCommand($"USE {datadase}", dbConn);
            cmdUseDb.ExecuteNonQuery();

            var qSelect = new MySqlCommand("select `first`, `last` , age, sum(answer)/count(answer) as `average answer` from answer \r\n\tjoin user on answer.userId = user.userId \r\n group by answer.userId; ", dbConn);
            List<(string first, string last, int age, double average)> minor = new();
            List<(string first, string last, int age, double average)> adult = new();

            var result = qSelect.ExecuteReader();


            if (result != null)
            {
                while (result.Read())
                {
                    var r = (result.GetString(0), result.GetString(1), result.GetInt32(2), result.GetDouble(3));

                    if (r.Item3 > 18)
                    {
                        adult.Add(r);
                    }
                    else
                    {
                        minor.Add(r);
                    }
                }
            }

            foreach (var rr in adult)
            {
                lbA.Items.Add($"{rr.last}, {rr.first} [{rr.age}] : {rr.average}");
            }
            foreach (var rr in minor)
            {
                lbM.Items.Add($"{rr.last}, {rr.first} [{rr.age}] : {rr.average}");
            }


            //if (result1 != null)
            //{
            //    result1.Read();

            //    lbM.Items.Add(result1.GetDouble(3));

            //    //result.Read();
            //    //lbM.Items.Add(result.GetDouble(1));
            //}

            //dataAdapter = new(qSelect);

            //var commandBuilder = new MySqlCommandBuilder(dataAdapter);

            ////dataAdapter.Fill(dataTable);

            ////var q = from row in dataTable.AsEnumerable()
            ////        where row.Field<int>("age").BiggerThan("18")
            ////        select row;

            //var dataView = new DataView(dataTable);

            //dataGridView1.DataSource = dataView;
        }
    }
}