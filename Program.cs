using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace text_analysis
{
    class Program
    {
        static void Main(string[] args) // В общем, беда такая:
                                        // он не читает кириллицу даже с кодировкой UTF8,
                                        // поэтому я в файл вставил английские стихи
        {
            string filename = "D:/Visual Studio ШАГ/C#/text analysis/bin/Debug/poetry.txt";
            StreamReader reader = new StreamReader(filename,Encoding.UTF8);
            Console.WriteLine("Чтение файла...");

            Regex regex = new Regex("[^a-zA-Z0-9 ]");

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = regex.Replace(line, "").ToLower().Split(' ');


                foreach (string word in words)
                {
                    if (word.Length >= 3 && word.Length <= 20)
                    {

                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts.Add(word, 1);
                        }
                    }
                }
            }
                reader.Close();

            var topWords = wordCounts.OrderByDescending(x => x.Value).Take(50);
            int i = 1;
            Console.WriteLine("+-----+-----------+----------------+");
            Console.WriteLine("|  #  |   Слово   |   Повторения   |");
            Console.WriteLine("+-----+-----------+----------------+");
            foreach (var pair in topWords)
            {
                Console.WriteLine("|  " + i++ + "  | " + "   {0}   " + "|   " + "   {1}",pair.Key, pair.Value + "\n-----------------------------------|");
            }
        }
    }
}