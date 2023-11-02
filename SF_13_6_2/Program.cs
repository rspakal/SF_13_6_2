using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace sf_13_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string filePath = @"SF_13_6_2.txt";
            var words = new List<string>();
            var dublicatedWords = new Dictionary<string, int>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    var str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        var wordsFromString = SplitString(str);
                        for (int i = 0; i < wordsFromString.Count; i++)
                        {
                            if (words.Contains(wordsFromString[i]))
                            {
                                if (!dublicatedWords.ContainsKey(wordsFromString[i]))
                                {
                                    dublicatedWords.Add(wordsFromString[i], 2);
                                }
                                else
                                {
                                    dublicatedWords[wordsFromString[i]]++;
                                }
                            }
                            words.Add(wordsFromString[i]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesnt exist");
            }
            int biggestAmountOfDublication = 0;
            string mostFriquentWord = default;
            if (dublicatedWords.Count > 9)
            {
                for (int i = 0; i < 10; i++)
                {
                    foreach (var w in dublicatedWords)
                    {
                        if (w.Value > biggestAmountOfDublication)
                        {
                            biggestAmountOfDublication = w.Value;
                            mostFriquentWord = w.Key;
                        }
                    }
                    Console.WriteLine("The Most Friquent Word number " + (i + 1) + " is " + mostFriquentWord);
                    Console.WriteLine("It repeats " + dublicatedWords[mostFriquentWord] + " times");
                    dublicatedWords.Remove(mostFriquentWord);
                    biggestAmountOfDublication = 0;
                }
            }
            Console.ReadKey();
        }
        static List<string> SplitString(string str)
        {
            List<string> words = new List<string>();
            string noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
            string word = "";
            for (int i = 0; i < noPunctuationText.Length; i++)
            {
                if (noPunctuationText[i] != ' ')
                {
                    word += noPunctuationText[i];
                }
                else
                {
                    if (word != "") words.Add(word);
                    word = "";
                }
            }
            return words;
        }
    }
}
