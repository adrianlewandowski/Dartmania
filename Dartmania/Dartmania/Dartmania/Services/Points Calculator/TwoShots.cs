using System;
using System.Collections.Generic;

namespace Dartmania.Services.Points_Calculator
{
    class TwoShots
    {
        public static string calculateFinish(Dictionary<string, int> triples, Dictionary<string, int> doubles, Dictionary<string, int> singles, int points, int iloscRzutow)
        {
            string result = null;
            if ((points <= 100))
            {
                int flag = 0;
                foreach (KeyValuePair<string, int> item in doubles)
                {
                    foreach (KeyValuePair<string, int> item2 in triples)
                    {
                        if (item2.Value + item.Value == points)
                        {
                            result = "Wyrzuć " + item2.Key + " " + item.Key;
                            flag = 1;
                        }
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        break;
                    }
                }

                if (flag != 1)
                {
                    foreach (KeyValuePair<string, int> item in doubles)
                    {
                        foreach (KeyValuePair<string, int> item2 in doubles)
                        {
                            if (item2.Value + item.Value == points)
                            {
                                result = "Wyrzuć" + item2.Key + " " + item.Key;
                                flag = 1;
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                }

                if (flag != 1)
                {
                    foreach (KeyValuePair<string, int> item in doubles)
                    {
                        foreach (KeyValuePair<string, int> item2 in singles)
                        {
                            if (item2.Value + item.Value == points)
                            {
                                result = "Wyrzuć " + item2.Key + " " + item.Key;
                                flag = 1;
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
