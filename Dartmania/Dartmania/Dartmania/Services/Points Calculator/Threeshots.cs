using System;
using System.Collections.Generic;

namespace Dartmania.Services.Points_Calculator
{
    public class ThreeShots
    {
        public static string calculateFinish(Dictionary<string, int> triples, Dictionary<string, int> doubles, Dictionary<string, int> singles, int points, int iloscRzutow)
        {
            string result = null;
            if ((points <= 170))
            {
                int flag = 0;
                foreach (KeyValuePair<string, int> item in doubles)
                {
                    foreach (KeyValuePair<string, int> item2 in triples)
                    {
                        foreach (KeyValuePair<string, int> item3 in triples)
                        {
                            if (item3.Value + item2.Value + item.Value == points)
                            {
                                result = "Wyrzuć " + item3.Key + " " + item2.Key + " " + item.Key;
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
                    if (flag == 1)
                    {
                        break;
                    }
                }

                if (flag != 1)
                {
                    foreach (KeyValuePair<string, int> item0 in singles)
                    {
                        foreach (KeyValuePair<string, int> item in doubles)
                        {
                            foreach (KeyValuePair<string, int> item2 in triples)
                            {
                                if (item2.Value + item.Value + item0.Value == points)
                                {
                                    result = "Wyrzuć " + item2.Key + " " + item0.Key + " " + item.Key;
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
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                }

                if (flag != 1)
                {
                    foreach (KeyValuePair<string, int> item in singles)
                    {
                        foreach (KeyValuePair<string, int> item1 in singles)
                        {
                            foreach (KeyValuePair<string, int> item2 in doubles)
                            {
                                if (item2.Value + item1.Value + item.Value == points)
                                {
                                    result = "Wyrzuć " + item.Key + " " + item1.Key + " " + item2.Key;
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
