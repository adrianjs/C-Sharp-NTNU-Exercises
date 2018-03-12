using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                StreamReader file = new StreamReader("../../Haavamaal.txt");
                string fileText = file.ReadToEnd();
                // Regex for removal of special characters
                fileText = Regex.Replace(fileText, @"[()',.!?:;-]", " ");
                string[] fileTextTab = fileText.Split();
                int currentStanza = 0;
                List<string> foundChars = new List<string>();
                Dictionary<string, int> startList = new Dictionary<string, int>();
                Dictionary<string, KeyValuePair<int, string>> finalList =
                    new Dictionary<string, KeyValuePair<int, string>>();
                int previousStanza = 1;
                for (int i = 0; i < fileTextTab.Length; i++)
                {
                    if (fileTextTab[i].ToLower() == "strofe")
                    {
                        ++currentStanza;
                    }

                    if (!foundChars.Contains(fileTextTab[i].ToLower()) && !IsNumber(fileTextTab[i]) &&
                        fileTextTab[i].ToLower() != "strofe" && fileTextTab[i] != "")
                    {
                        string stanzaCounter = "Strofe: " + currentStanza;
                        foundChars.Add(fileTextTab[i].ToLower());
                        startList.Add(fileTextTab[i], 1);
                        KeyValuePair<int, string> tempElement = new KeyValuePair<int, string>(1, stanzaCounter);
                        finalList.Add(fileTextTab[i].ToLower(), tempElement);
                    }
                    else if (foundChars.Contains(fileTextTab[i]))
                    {
                        foreach (KeyValuePair<string, int> s in startList.ToList())
                        {
                            if (s.Key == fileTextTab[i])
                            {
                                int index = startList.Keys.ToList().IndexOf(fileTextTab[i]);
                                startList[startList.ElementAt(index).Key] = startList.ElementAt(index).Value + 1;
                                int tempInt = finalList.ElementAt(index).Value.Key + 1;
                                string tempString = finalList.ElementAt(index).Value.Value;
                                if (!InSameStanza(currentStanza, previousStanza))
                                {
                                    tempString += "," + currentStanza;
                                    previousStanza = currentStanza;
                                }
                                else
                                {
                                    // adds a plus(+) if detects duplicates
                                    tempString += "+";
                                }

                                KeyValuePair<int, string> tempElement =
                                    new KeyValuePair<int, string>(tempInt, tempString);
                                finalList[finalList.ElementAt(index).Key] = tempElement;
                            }
                        }
                    }
                }

                Console.WriteLine(" STARTING PROGRAM ");
                PrintList(ToList(finalList));
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("\n PROGRAM ENDED \n");
            }
        }
        
        // Checks if given string is an int
        private static bool IsNumber(string s)
        {
            return int.TryParse(s, out _);
        }
        
        // Helper method for printing data from List object
        private static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        
        // Helper method for converting Dictionary class to List class
        private static List<string> ToList(Dictionary<string, KeyValuePair<int, string>> element)
        {
            List<string> temp = new List<string>();
            foreach (KeyValuePair<string,KeyValuePair<int,string>> kvp in element)
            {
                temp.Add(kvp.Key + "\t | ganger: " + kvp.Value.Key + "\t | strofer: \t" + CountPluses(kvp.Value.Value));
            }

            temp.Sort();
            return temp;
        }

        // Checks if two chars are in same stanza
        private static bool InSameStanza(int i, int j)
        {
            return i == j;
        }

        // Method for counting number of duplicates
        private static string CountPluses(string s)
        {
            string temp = "";
            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!IsNumber(s[i].ToString()) && s[i].ToString() == "+")
                {
                    counter++;
                }
                else if (IsNumber(s[i].ToString()))
                {
                    if (counter != 0)
                    {
                        counter++;
                        temp += "(x" + counter + ") ";
                    }

                    temp += s[i].ToString();
                    counter = 0;
                }
                else if (s[i].ToString() == ",")
                {
                    temp += " ";
                }
            }

            counter++;
            if (counter != 1)
            {
                temp += " (x" + counter + ")";
            }

            return temp;
        }
    }
}