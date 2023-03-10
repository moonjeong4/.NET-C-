using TicTacToe;

namespace Quiz2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticTacToeGrid1.Reset();
            ticTacToeGrid1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ticTacToeGrid1.Dimensions = trackBar1.Value;
        }

        private void ticTacToeGrid1_OnPlayerMove(TicTacToe.TicTacToeGrid sender, TicTacToe.Player player, int x, int y)
        {

            label1.Text = "The current player is " + sender.CurrentPlayer.ToString();


            listBox1.Items.Clear();

            foreach ((Player, int, int) pp in sender.MoveHistory)
            {
                listBox1.Items.Add(pp);
            }
        }

        private void ticTacToeGrid1_OnGameOver(TicTacToeGrid sender, TileState winningPlayer)
        {
            MessageBox.Show("Game over! The winner is: " + winningPlayer);
            sender.Enabled = false;

            listBox1.Items.Add(DateTime.Now);
        }


    }
}














