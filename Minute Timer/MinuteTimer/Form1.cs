namespace FinalExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Add_Click(object sender, EventArgs e)
        {

            var mt = new TControl() { TotalSeconds = hScrollBar1.Value };

            flowLayoutPanel1.Controls.Add(mt);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = hScrollBar1.Value.ToString();
        }
    }
}