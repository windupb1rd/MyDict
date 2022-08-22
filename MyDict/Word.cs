using ConsoleDictionary;
using Microsoft.EntityFrameworkCore;
using MyDict.Model;
using System.Reflection;

namespace MyDict
{
    public class Word
    {
        private readonly WordCard _wordCard;
        private readonly AppDbContext _context;
        private readonly string _query;
        private int _id;

        public Word(string query)
        {
            _wordCard = new WordCard();
            _context = new AppDbContext();
            _query = query;
        }

        /// <summary>
        /// Вывод слова в консоль
        /// </summary>
        public void PrintWord()
        {
            if (_wordCard != null)
                new WordToConsolePrinter().Print(_wordCard);
        }

        public void SearchWordInDb()
        {
            var wordQuery = _context.words.Select(w => w).Where(w => w.EnglishWord == _query);
            if (wordQuery.Count() == 0)
            {
                Console.WriteLine("empty result");
            }
            else
            {
                _id = wordQuery.First().Id;
                Console.WriteLine(_id);
            }
        }

        public void SearchWordInApi()
        {

        }

        public void CreateCard()
        {
            var w = new WordModel();
            w.EnglishWord = _wordCard.Word;
            w.Transcription = _wordCard.Pronunciation;

            foreach (var def in _wordCard.Definitions)
            {
                for (int i = 0; i < _wordCard.Definitions[def.Key].Count; i++)
                {
                    string propName = $"Definition{i + 1}";
                    var splitDefAndEx = def.Value[i].Split("\n\t");
                    if (w.GetType().GetProperty(propName).GetValue(w) == null)
                    {
                        w.GetType().GetProperty(propName).SetValue(w, $"{def.Key} | {splitDefAndEx[0]}");
                        w.GetType().GetProperty($"Example{i+1}").SetValue(w, $"{splitDefAndEx[1]}");
                    }
                }
            }

            _context.Add(w);
            _context.SaveChanges();
        }

        public void FetchWord()
        {

        }

        private void DeleteWord()
        {
            
        }
    }
}
