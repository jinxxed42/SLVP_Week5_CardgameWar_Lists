namespace SLVP_Week5_CardgameWar_Lists
{
    public partial class Form1 : Form
    {
        Game g = new Game();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                g.FillDeck();
                btnPlay.Text = "Play";
            }

            g.PlayRound();
            Update();
        }


        public void Update()
        {
            rtbGame.Text = "Player 1 drew a " + g.Player1Card.Value.ToString() + " of " + g.Player1Card.Suit.ToString() + "\n";
            rtbGame.Text += "Player 2 drew a " + g.Player2Card.Value.ToString() + " of " + g.Player2Card.Suit.ToString() + "\n";

            tbPlayer1.Text = g.Player1Score.ToString();
            tbPlayer2.Text = g.Player2Score.ToString();

            if (g.GameOver)
            {
                btnPlay.Text = "Start game!";
                rtbGame.Text += "\n";
                if (g.GameWinner == "Draw")
                {
                    MessageBox.Show("The game is over and it was a draw!");
                }
                else
                {
                    MessageBox.Show("The game is over and the winner is: " + g.GameWinner + "!");
                }
            }
        }
    }
}