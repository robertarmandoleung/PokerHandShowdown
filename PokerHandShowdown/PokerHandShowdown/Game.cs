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
    public class Game
    {
        List<Card> playerCards { get; set; }
        List<Hand> playerHands { get; set; }

        public Game()
        {
            newGame();
        }

        private void newGame()
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

        private void addHand(Hand playerHand)
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
            var groupedHandsByValue = orderedHands.GroupBy(hand => hand.TypeOfHand).First().GroupBy(hand => hand.HighestValue).First().ToList();

            int groupCount = groupedHandsByValue.Count();

            if (groupCount > 1)
            {
                var firstCards = groupedHandsByValue.First().cards;
                var lastCards = groupedHandsByValue.Last().cards;
                for (int i = 0; i < groupCount - 1; i++)
                {
                    removeDuplicates(ref groupedHandsByValue, lastCards, i);
                }
                removeDuplicates(ref groupedHandsByValue, lastCards, groupCount - 1);
            }

            groupedHandsByValue.ForEach(item => item.evalHand());

            Hand winner = groupedHandsByValue.OrderByDescending(win => win.HighestValue).First();

            Console.WriteLine("Given the following players and their hands, the winner is: " + winner.Player);

            printHands();

            newGame();
        }

        private void removeDuplicates(ref List<Hand> removalList, List<Card> keys, int index)
        {
            removalList.ElementAt(index).cards = removalList.ElementAt(index).cards.Where(x => !keys.Any(y => y.CardValue == x.CardValue)).ToList();
        }

        public void printHands()
        {
            foreach (Hand hands in playerHands)
            {
                Console.WriteLine(hands.Player + ": " + hands.playerHand);
            }
        }

    }

}
