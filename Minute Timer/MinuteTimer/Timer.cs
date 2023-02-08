using Timer = System.Windows.Forms.Timer;

namespace FinalExam;



public partial class TControl : UserControl
{

    public TControl()
    {
        InitializeComponent();
    }

    Timer t = new Timer() { Interval = 1000 };
    private void TControl_Load(object sender, EventArgs e)
    {

        label2.Text = "Timer:   " + TotalSeconds.ToString() + " seconds";

    }

    private void T_Tick(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            if (progressBar1.Value != TotalSeconds)
            {
                progressBar1.Value++;
                label1.Text = progressBar1.Value.ToString() + " seconds";
            }
            else
            {
                t.Stop();
                MessageBox.Show("Over!");
            }
        }
    }

    private void Start_Click(object sender, EventArgs e)
    {
        t.Tick += T_Tick;


        t.Enabled = true;

        progressBar1.Maximum = TotalSeconds;
    }

    public int TotalSeconds
    {
        get; set;
    }

    private void Restart_Click(object sender, EventArgs e)
    {
        t.Stop();


        progressBar1.Value = 0;
        t.Start();
    }



    private void Remove_Click(object sender, EventArgs e)
    {
        t.Stop();
        this.Parent.Controls.Remove(this);
    }


    private void Pause_Click(object sender, EventArgs e)
    {
        t.Stop();
    }

    private void Continue_Click(object sender, EventArgs e)
    {
        t.Start();
    }
}
