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
            pokerTest1();       /*All variations of hands*/
            pokerTest2();       /*Assignment example*/
            pokerTest3();       /*Erroneous output*/
            pokerTest4();
            Console.ReadLine();
        }

        public static void pokerTest1()
        {
            Game pokerHands = new PokerHandShowdown.Game();
            pokerHands.addPlayer("Bob", "5D,5S,3D,2D,AD");              // Pair example
            pokerHands.addPlayer("Max", "7D,7S,7H,7C,AS");              // Three of a kind
            pokerHands.addPlayer("Joe", "5H,4H,3H,2H,AH");              // Flush example
            pokerHands.addPlayer("Pete", "6D,6S,6H,6C,2S");             // Test 4 of a kind - should result in a three of a kind, since it is not in the subset
            pokerHands.addPlayer("Ali", "TC,9S,8C,JC,QC");              // High card examples
            pokerHands.addPlayer("Joey", "TS,KS,5C,JS,QS");
            pokerHands.evaluateHands();
        }

        public static void pokerTest2()
        {
            Game pokerHands2 = new PokerHandShowdown.Game();
            pokerHands2.addPlayer("Joe", "3H, 4D, 9C, 9D, QH");
            pokerHands2.addPlayer("Jen", "5C, 7D, 9H, 9S, QS");
            pokerHands2.evaluateHands();
        }


        public static void pokerTest3()
        {
            Game pokerHands3 = new PokerHandShowdown.Game();
            pokerHands3.addPlayer("Joe", "6HH,DHD,T3D,A2D,5AD");
            pokerHands3.addPlayer("Joe", "6HH,DHD,T3D,A2D,5AD");
            pokerHands3.evaluateHands();
        }

        public static void pokerTest4()
        {
            Game pokerHands4 = new PokerHandShowdown.Game();
            pokerHands4.addPlayer("Joe", "6H,TH");
            pokerHands4.evaluateHands();
        }

    }
}
