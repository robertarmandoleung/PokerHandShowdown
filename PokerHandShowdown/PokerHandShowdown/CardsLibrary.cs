using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    public class CardsLibrary
    {

        public static int HAND_SIZE = 5;
        public static int DECK_SIZE = Enum.GetNames(typeof(CardSuits)).Length * Enum.GetNames(typeof(CardValues)).Length;

        public enum CardSuits
        {
            Spade = 1,
            Heart,
            Club,
            Diamond
        };

        public enum CardValues
        {
            Two = 1,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        };

        public enum HandType
        {
            HighCard = 1,
            Pair,
            ThreeOfAKind,
            Flush
        };

    }

}
