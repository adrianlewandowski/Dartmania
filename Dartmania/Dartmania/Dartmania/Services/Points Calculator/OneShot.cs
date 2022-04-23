using System;
using System.Collections.Generic;

namespace Dartmania.Services.Points_Calculator
{
    class OneShot
    {
        public static string calculateFinish(Dictionary<string, int> doubles, int points, int iloscRzutow)
        {
            string result = null;
            if (points <= 40)
            {

                foreach (KeyValuePair<string, int> item in doubles)
                {
                    if (item.Value == points)
                    {
                        result = "Wyrzuć " + item.Key;
                    }
                }
            }
            return result;
        }
    }
}
