namespace Lab4;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        //string? line;
        //using StreamReader sr = new("rndnum.csv");
        //uint lineCount = 0;
        ////List<(int, int, int)> lll = new();



        //while ((line = sr.ReadLine()) != null)
        //{
        //    string[] line1 = line.Split(',');
        //    //var Out = new int[] { line1 };
        //    List<int> Out = new List<int>();


        //        if(lineCount == 0)
        //        {
        //            textBox1.Text += (line);
        //        }
        //        else
        //        {
        //            textBox1.Text += ("\r\n" + line);
        //        }

        //        lineCount++;
        ProcessFile("rndnum.csv");

    }

    public void ProcessFile(string file)
    {

        using StreamReader reader = new StreamReader(file);
        string line;

        textBox1.Clear();

        while ((line = reader.ReadLine()) != null)
        {

            var stats = ProcessLine(line);

            textBox1.Text += "min: " + stats.min + "\tmax: " + stats.max + "\tavg "
                + stats.avg + "\r\n";
        }


    }


    public static (int min, int max, float avg) ProcessLine(string line)
    {
        //uint min = uint.MaxValue, max = 0, Count = 0, sum = 0;

        string[] stringNums = line.Split(',');

        uint first = uint.Parse(stringNums[0]);

        uint min = first, max = first, count = 0, sum = 0;


        foreach (string s in stringNums)
        {

            uint n = uint.Parse(s);

            if (n < min)
            {
                min = n;
            }

            if (n > max)
            {

                max = n;
            }
            sum += n;
            count++;
        }
        return ((int)min, (int)max, sum / (float)count);

    }
}