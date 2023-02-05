namespace Quiz1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        label1.Text = hScrollBar1.Value.ToString();
    }

    private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
        label1.Text = hScrollBar1.Value.ToString();
    }

    private int numB = 0;
    private void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < hScrollBar1.Value; i++)
        {
            Button button = new();
            button.Text = "" + numB++;

            button.Click += Button_Click;
            flowLayoutPanel1.Controls.Add(button);

        }

    }
    private void Button_Click(object? sender, EventArgs e)
    {
        if (sender != null)
        {

            DialogResult r = MessageBox.Show("Do you want to clear all button(s)?", "",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

            if (r == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                numB = 0;
            }
        }
    }

}
