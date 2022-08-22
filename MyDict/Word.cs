using DictApi;
using Microsoft.EntityFrameworkCore;
using MyDict.Model;
using System.Reflection;

namespace MyDict
{
    public class Word
    {
        private static readonly AppDbContext _context = new AppDbContext();
        private WordCard _wordCard;
        private WordModel _wordInstance;
        private readonly string _query;
        //private int _id;

        public Word(string query)
        {
            _query = query;
            SearchWordInDb();
        }

        public void SearchWordInDb()
        {
            _wordInstance = _context.words.Where(w => w.EnglishWord == _query).FirstOrDefault();
            if (_wordInstance != null)
            {
                //_id = _wordInstance.Id;
                Console.WriteLine($"Слово {_wordInstance.EnglishWord} было найдено в БД. ID = {_wordInstance.Id}"); // debug
            }
            else
            {
                _wordInstance = new WordModel();
                SearchWordInApi();
                Console.WriteLine($"Слово {_query} было запрошено с API."); // debug
            }
        }

        public void SearchWordInApi()
        {
            if (_wordCard == null)
            {
                _wordCard = new WordCard();
                _wordCard.FormWordCard(_query);
            }
        }

        public void CreateCard()
        {
            if (_wordInstance.Id == 0)
            { 
                _wordInstance.EnglishWord = _wordCard.Word;
                _wordInstance.Transcription = _wordCard.Pronunciation;

                foreach (var def in _wordCard.Definitions)
                {
                    for (int i = 0; i < def.Value.Count && i < 5; i++)
                    {
                        string propName = $"Definition{i + 1}";
                        var splitDefAndEx = def.Value[i].Split("\n\t");
                        if (_wordInstance.GetType().GetProperty(propName).GetValue(_wordInstance) == null)
                        {
                            _wordInstance.GetType().GetProperty(propName).SetValue(_wordInstance, $"{def.Key} | {splitDefAndEx[0]}");
                            _wordInstance.GetType().GetProperty($"Example{i+1}").SetValue(_wordInstance, $"{splitDefAndEx[1]}");
                        }
                    }
                }
                _context.Add(_wordInstance);
                _context.SaveChanges();
                

                Console.WriteLine($"Слово {_wordInstance.EnglishWord} было записано в БД. ID = {_wordInstance.Id}"); // debug
            }
            else
                Console.WriteLine($"Слово {_wordInstance.EnglishWord} не было записано в БД, так как уже существует ID = {_wordInstance.Id}"); // debug
        }

        public void DeleteWord()
        {
            var itemToRemove = _context.words.Where(w => w.Id == _wordInstance.Id).Single();
            _context.words.Remove(itemToRemove);

            _context.SaveChanges();

            Console.WriteLine($"Слово {itemToRemove.EnglishWord} было удалено из БД. ID = {_wordInstance.Id}"); // debug
        }

        /// <summary>
        /// Вывод слова в консоль
        /// </summary>
        public void PrintWord()
        {
            if (_wordCard != null)
                new WordToConsolePrinter().Print(_wordCard);
        }

        public void CalculateNextReviewDate()
        {
            _wordInstance.NextReview = DateTime.Now;
        }

        public void SetStatus()
        {
            _wordInstance.IsOnLearning = true;
        }
    }
}
