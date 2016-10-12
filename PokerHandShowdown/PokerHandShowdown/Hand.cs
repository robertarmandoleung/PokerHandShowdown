using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    class Hand
    {
        public List<Card> cards {get; set;}
        public String Player { get; set; }
        public String playerHand { get; set; }

        /*Evaluation variables*/
        public CardsLibrary.HandType TypeOfHand { get; set; }
        public CardsLibrary.CardValues HighestValue { get; set; }
        public CardsLibrary.CardSuits HighestSuit { get; set; }

        public Hand(String playerName, List<Card> cardsInput, String playerHandInput)
        {
            cards = cardsInput;
            Player = playerName;
            playerHand = playerHandInput;
            evalHand();
        }

        public void evalHand()
        {
            var sorted = cards.OrderByDescending(val => val.CardValue).ThenBy(suit => suit.CardSuit);
            IEnumerable<IGrouping<CardsLibrary.CardValues, Card>> valueGroup = sorted.GroupBy(card => card.CardValue).OrderByDescending(cnt => cnt.Count());
            cards = valueGroup.SelectMany(card => card).ToList();
            checkPairings(valueGroup); 
            isFlush(sorted);
        }

        private void checkPairings(IEnumerable<IGrouping<CardsLibrary.CardValues, Card>> valueGroup)
        {
            foreach (IGrouping<CardsLibrary.CardValues, Card> pairGroup in valueGroup)
            {
                if (pairGroup.Count() == 1)
                {
                    setHighestValues(CardsLibrary.HandType.HighCard, pairGroup.First<Card>());
                }
                if (pairGroup.Count() == 2)
                {
                    setHighestValues(CardsLibrary.HandType.Pair, pairGroup.First<Card>());
                }
                else if (pairGroup.Count() == 3 || pairGroup.Count() == 4)
                {
                    setHighestValues(CardsLibrary.HandType.ThreeOfAKind, pairGroup.First<Card>());
                }
                return; 
            }
        }

        private void isFlush(IEnumerable<Card> cards)
        {
            if (cards.GroupBy(card => card.CardSuit).Any(group => group.Count() == 5))
            {
                setHighestValues(CardsLibrary.HandType.Flush, cards.First<Card>());
            }
        }

        private void setHighestValues(CardsLibrary.HandType type, Card card)
        {
            TypeOfHand = type;
            HighestSuit = card.CardSuit;
            HighestValue = card.CardValue;
        }

    }
}
