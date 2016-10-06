/* Class Deck - Generates a new deck */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* A new "shuffled" deck should be created. 
 * An option to start a new game with the deck should be given. 
 * Therefore, there should be an option to re-shuffle */

namespace PokerHandShowdown
{
    class Game
    {
        public static List<Card> playerCards { get; set; }
        public static List<Hand> playerHands { get; set; }

        public Game()
        {
            newGame();
        }

        private static void newGame()
        {
            playerCards = new List<Card>();
            playerHands = new List<Hand>();
        }

        public void addPlayer(String playerName, String playerHand)
        {
            var splitString = playerHand.Split(',');
            List<Card> createHand = new List<Card>();
            if (splitString.Count() != CardsLibrary.HAND_SIZE)
            {
                throw new ArgumentException("Invalid input: hand inputted does not equal: " + CardsLibrary.HAND_SIZE);
            }
            foreach (String entry in splitString)
            {
                createHand.Add(new Card(entry.Trim().ToLower()));
            }
            Hand hand = new Hand(playerName, createHand, playerHand);
            addHand(hand);
        }

        public void addHand(Hand playerHand)
        {
            playerCards.AddRange(playerHand.cards);
            int distinctCount = playerCards.GroupBy(props => new { props.CardValue, props.CardSuit }).Select(x => x.First()).Count();

            if (distinctCount < (CardsLibrary.HAND_SIZE) * (playerHands.Count() + 1) || distinctCount > CardsLibrary.DECK_SIZE)
            {
                throw new ArgumentException("Error: Cheater! Found duplicated cards!");
            }

            playerHands.Add(playerHand);
        }

        public void evaluateHands()
        {
            if (!(playerHands.Count() > 1))
            {
                throw new ArgumentException("Error: Not enough players have been added to start a game.");
            }
            var orderedHands = playerHands.OrderByDescending(hand => hand.TypeOfHand).ThenByDescending(val => val.HighestValue).ThenBy(suit => suit.HighestSuit);

            Console.WriteLine("Given the following players and their hands, the winner is: " + orderedHands.ElementAt(0).Player + "\n");
            Console.Write("WINNER: ");

            foreach (Hand hands in orderedHands)
            {
                Console.WriteLine(hands.Player + ": " + hands.TypeOfHand + " (" + hands.HighestValue + " of " + hands.HighestSuit + " high) --- Hand: " + hands.playerHand);
            }
            newGame();
        }



    }

}
