using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandShowdown
{
    class Card
    {
        public CardsLibrary.CardValues CardValue { get; set; }
        public CardsLibrary.CardSuits  CardSuit { get; set; }

        protected Card() { }

        public Card(String stringCardInput)
        {
            inputToCard(stringCardInput);
        }

        public Card(CardsLibrary.CardValues value, CardsLibrary.CardSuits suit)
        {
            CardValue = value;
            CardSuit = suit;
            if (!cardIsValid())
            {
                throw new System.ArgumentException("Entered card value or suit is not valid.");
            }
        }

        private bool cardIsValid()
        {
            return (Enum.IsDefined(CardValue.GetType(), CardValue)
                && Enum.IsDefined(CardSuit.GetType(), CardSuit));
        }

        public void inputToCard(String cardInput)
        {
            if (cardInput == null || cardInput.Length != 2)
            {
                throw new ArgumentException("Invalid input for card: " + cardInput);
            }
            CardValue = stringToValue(cardInput);
            CardSuit = stringToSuit(cardInput);
        }

        private static CardsLibrary.CardSuits stringToSuit(String cardInput)
        {
            switch (cardInput.Last())
            {
                case 's':
                    return CardsLibrary.CardSuits.Spade;
                case 'h':
                    return CardsLibrary.CardSuits.Heart;
                case 'c':
                    return CardsLibrary.CardSuits.Club;
                case 'd':
                    return CardsLibrary.CardSuits.Diamond;
                default:
                    throw new ArgumentException("Invalid suit passed as an argument on: " + cardInput);
            }
        }

        private CardsLibrary.CardValues stringToValue(String cardInput)
        {
            switch (cardInput.First())
            {
                case '2':
                    return CardsLibrary.CardValues.Two;
                case '3':
                    return CardsLibrary.CardValues.Three;
                case '4':
                    return CardsLibrary.CardValues.Four;
                case '5':
                    return CardsLibrary.CardValues.Five;
                case '6':
                    return CardsLibrary.CardValues.Six;
                case '7':
                    return CardsLibrary.CardValues.Seven;
                case '8':
                    return CardsLibrary.CardValues.Eight;
                case '9':
                    return CardsLibrary.CardValues.Nine;
                case 't':
                    return CardsLibrary.CardValues.Ten;
                case 'j':
                    return CardsLibrary.CardValues.Jack;
                case 'q':
                    return CardsLibrary.CardValues.Queen;
                case 'k':
                    return CardsLibrary.CardValues.King;
                case 'a':
                    return CardsLibrary.CardValues.Ace;
                default:
                    throw new ArgumentException("Invalid value passed as an argument on: " + cardInput);
            }
        }

    }
}
