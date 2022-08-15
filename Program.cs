using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deck_of_cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("1) взять карту \n2) перемешать колоду " +
                    "\n3) показать взятые карты \n4) выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':
                        player.GetCard(deck.GiveGardAway());
                        Console.WriteLine("Вы взяли карту");
                        break;
                    case '2':
                        deck.ShuffleDeck();
                        Console.WriteLine("Колода перемешана");
                        break;
                    case '3':
                        Console.WriteLine("У вас в руках сейчас:");
                        player.ShowInfo();
                        break;
                    case '4':
                        isPlaying = false;
                        Console.WriteLine("Благодарим за игру \nУ вас в руках сейчас:");
                        player.ShowInfo();
                        break;
                        default: 
                        Console.WriteLine("Неверно выбрана команда");
                        break;
                }

                if (deck.IsDeckEmpty())
                {
                    Console.WriteLine("В колоде закончились карты");
                    isPlaying = false;
                    Console.WriteLine("У вас в руках сейчас:");
                    player.ShowInfo();
                }

                Console.ReadKey(true);
            }
        }

    }

    class Player
    {
        private List<Card> _playerCards = new List<Card>();

        public Player()
        {
            _playerCards = new List<Card>(0);
        }

        public void GetCard(Card card)
        {
            _playerCards.Add (card);
        }

        public void ShowInfo()
        {
            foreach (Card card in _playerCards)
            {
                Console.WriteLine(card.CardName + " " + card.Suit);
            }
        }
    }

    class Deck
    {
        private List<Card> _deck = new List<Card>();
        private List<string> _cardsName = new List<string>();
        private List<string> _suits = new List<string>();

        
        public Deck()
        {
            _cardsName.AddRange(new string[] { "шестерка", "семерка", "восьмерка", "девятка", "десятка", "валет", "дама", "король", "туз"});
            _suits.AddRange(new string[] { "бубны", "пики", "червы", "трефы"});

            foreach (string cardName in _cardsName)
            {
                foreach (string suit in _suits)
                {
                    _deck.Add(new Card(cardName, suit));
                }
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();

            for (int i = 0; i < _deck.Count; i++)
            {
                int shuffleIndex = random.Next(0, _deck.Count);
                Card swappCard = _deck[i];
                _deck[i] = _deck[shuffleIndex];
                _deck[shuffleIndex] = swappCard;
            }
        }

        public bool IsDeckEmpty()
        {
            if (_deck.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Card GiveGardAway ()
        {
            Card card = _deck[0];
            _deck.RemoveAt(0);
            return card;
        }
    }

    class Card
    {
        public string CardName { get ; }
        public string Suit { get ; }

        public Card(string cardName, string suit)
        {
            CardName = cardName;
            Suit = suit;   
        }
    }
}
