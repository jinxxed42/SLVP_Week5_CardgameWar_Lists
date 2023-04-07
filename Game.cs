using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week5_CardgameWar_Lists
{
    internal class Game
    {
        private List<Card> deck;
        public Card Player1Card { get; private set; }
        public Card Player2Card { get; private set; }
        public string RoundWinner { get; private set; }
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public bool GameOver { get; private set; }

        public string GameWinner { get; private set; }


        static Random rand = new Random();

        public Game()
        {
        }

        public void FillDeck()
        {
            GameOver = false;
            deck = new List<Card>();

            Player1Score = 0;
            Player2Score = 0;

            foreach (CardSuit cSuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cValue in Enum.GetValues(typeof(CardValue)))
                {
                    deck.Add(new Card(cValue, cSuit));
                }
            }
        }

        public Card SelectCard()
        {
            int index = rand.Next(0, deck.Count - 1);
            Card c = deck[index];
            deck.RemoveAt(index);
            return c;
        }

        public void PlayRound()
        {
            Player1Card = SelectCard();
            Player2Card = SelectCard();

            if (Player1Card.Value > Player2Card.Value)
            {
                Player1Score += 2;
                RoundWinner = "Player1";
            }
            else if (Player1Card.Value < Player2Card.Value)
            {
                Player2Score += 2;
                RoundWinner = "Player2";
            }
            else
            {
                Player1Score++;
                Player2Score++;
                RoundWinner = "Draw";
            }

            if (deck.Count == 0)
            {
                GameOver = true;
                if (Player1Score > Player2Score)
                {
                    GameWinner = "Player1";
                }
                else if (Player1Score < Player2Score)
                {
                    GameWinner = "Player2";
                }
                else
                {
                    GameWinner = "Draw";
                }
            }
        }
    }
}
