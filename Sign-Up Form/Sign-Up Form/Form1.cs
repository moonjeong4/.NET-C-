namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Signee signee = new(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            listBox1.Items.Add(signee);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != null)
            {
                Signee signee = (Signee)listBox1.SelectedItem;
                textBox1.Text = signee.First;
                textBox2.Text = signee.Last;
                textBox3.Text = signee.Number;
                textBox4.Text = signee.Email;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}