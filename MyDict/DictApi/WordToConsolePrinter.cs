using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictApi
{
    public class WordToConsolePrinter
    {
        public void Print(WordCard wordCard)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{wordCard.Word}   {wordCard.Pronunciation}\n--------------------");

            Console.ForegroundColor = ConsoleColor.White;
            PrintDefinition(wordCard);
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        private void PrintDefinition(WordCard wordCard)
        {
            foreach (var partOfSpeech in wordCard.Definitions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{partOfSpeech.Key.ToUpper()}\t");

                PrintSynonyms(wordCard.Synonyms, partOfSpeech);

                Console.WriteLine();
                Console.WriteLine("--------------------");
                Console.ForegroundColor = ConsoleColor.White;

                PrintDefinitions(partOfSpeech);
            }
        }

        private void PrintDefinitions(KeyValuePair<string, List<string>> partOfSpeech)
        {
            int maxDefinitions = 5;
            for (int i = 0; i < partOfSpeech.Value.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {partOfSpeech.Value[i]}");
                if (i == maxDefinitions - 1)
                {
                    break;
                }
            }
        }

        private void PrintSynonyms(Dictionary<string, List<string>> synonyms, KeyValuePair<string, List<string>> partOfSpeech)
        {
            int maxSynonyms = 5;
            for (int i = 0; i < synonyms[partOfSpeech.Key].Count; i++)
            {
                Console.Write($"| {synonyms[partOfSpeech.Key][i]} |");
                if (i == maxSynonyms - 1)
                {
                    break;
                }
            }
        }
    }
}
