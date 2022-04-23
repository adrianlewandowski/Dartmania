using System;
using System.Collections;
using System.Collections.Generic;

namespace Dartmania.Services.Points_Calculator
{
    class Calculator
    {
        public static int points = 501;
        //public static int rzut;
        public static int iloscRzutow = 3;
        public static Dictionary<string, int> triples = new Dictionary<string, int> { {"T1", 3}, {"T2", 6}, {"T3", 9}, { "T4", 12}, {"T5", 15}, { "T6", 18 }, { "T7", 21 },
        {"T8", 24}, {"T9", 27}, {"T10", 30}, {"T11", 33}, {"T12", 36}, {"T13", 39}, {"T14", 42}, {"T15", 45}, {"T16", 48}, {"T17", 51}, {"T18", 54}, {"T19", 57}, {"T20", 60}};
        public static Dictionary<string, int> doubles = new Dictionary<string, int> { {"D1", 2}, { "D2", 4 }, { "D3", 6 }, { "D4", 8 }, { "D5", 10 }, { "D6", 12 },
        {"D7", 14}, {"D8", 16}, {"D9", 18}, {"D10", 20}, {"D11", 22}, {"D12", 24}, {"D13", 26}, {"D14", 28}, {"D15", 30}, {"D16", 32}, {"D17", 34},
        {"D18", 36}, {"D19", 38}, {"D20", 40}, {"DB", 50} };
        public static Dictionary<string, int> singles = new Dictionary<string, int> { {"1", 1}, { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
        {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10}, {"11", 11}, {"12", 12}, {"13", 13}, {"14", 14}, {"15", 15}, {"16", 16}, {"17", 17}, {"18", 18},
        {"19", 19}, {"20", 20}, {"B", 25}};
        static string Main(int points, int rzut, int iloscRzutow)
        {
            string result = "";
            while (points != 0)
            {
                Console.WriteLine("Ilosc rzutów: " + iloscRzutow);
                Console.WriteLine("Twoja liczba punktów wynosi: " + points);
                if ((points <= 170) && (iloscRzutow == 3))
                {
                    result = ThreeShots.calculateFinish(triples, doubles, singles, points, iloscRzutow);
                    Console.WriteLine(result);
                }
                else if ((points <= 100) && (iloscRzutow == 2))
                {
                    result = TwoShots.calculateFinish(triples, doubles, singles, points, iloscRzutow);
                    Console.WriteLine(result);
                }
                else if ((points <= 40) && (iloscRzutow == 1))
                {
                    result = OneShot.calculateFinish(doubles, points, iloscRzutow);
                    Console.WriteLine(result);
                }

                Console.WriteLine("Wpisz ilość rzuconych punktów: ");
                string userInput = Console.ReadLine();
                rzut = Int32.Parse(userInput);
                points -= rzut;
                iloscRzutow--;

                if (points < 0)
                {
                    Console.WriteLine("Fura!");
                    points += rzut;
                    Console.WriteLine("Twoja liczba punktów wynosi: " + points);
                }
                else if (points == 1)
                {
                    Console.WriteLine("Fura!");
                    points += rzut;
                    Console.WriteLine("Twoja liczba punktów wynosi: " + points);
                }
            }
            return result;
        }
    }
}