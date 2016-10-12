using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokerHandShowdown
{
    class Program
    {

        static void Main(string[] args)
        {
            Game pokerHands = new PokerHandShowdown.Game();

            pokerHands.addPlayer("Bob", "5D,5S,3D,2D,AD");              // Pair example
            pokerHands.addPlayer("Max", "7D,7S,7H,7C,AS");              // Three of a kind
            pokerHands.addPlayer("Joe", "5H,4H,3H,2H,AH");              // Flush example
            pokerHands.addPlayer("Pete", "6D,6S,6H,6C,2S");             // Test 4 of a kind - should result in a three of a kind, since it is not in the subset
            pokerHands.addPlayer("Ali", "TC,9S,8C,JC,QC");              // High card examples
            pokerHands.addPlayer("Joey", "TS,KS,5C,JS,QS");

            /*pokerHands.addPlayer("Joe", "3H, 4D, 9C, 9D, QH");
            pokerHands.addPlayer("Jen", "5C, 7D, 9H, 9S, QS");
            pokerHands.addPlayer("Jen", "JC, KD, 4H, 3S, 2S");*/

            // Duplicate cards example
            // pokerHands.addPlayer("Joe", "5D,4D,3D,2D,AD");

            // Error card example 1: Erroneous input
            // pokerHands.addPlayer("Joe", "6HH,DHD,T3D,A2D,5AD");
            // pokerHands.addPlayer("Joe", "6HH,DHD,T3D,A2D,5AD");

            // Error card example 2: too little cards
            // pokerHands.addPlayer("Joe", "6HH,DHD,T3D,A2D,5AD");



            pokerHands.evaluateHands();
            Console.ReadLine();
        }

    }
}
