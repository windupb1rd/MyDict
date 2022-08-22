using DictApi.FreeDict;
using System.Collections.Generic;
using System.Linq;

namespace DictApi
{
    public class WordCard
    {
        private readonly FreeDictionaryApi freeDictionaryApiObj;

        internal string Word { get; private set; }

        internal string Pronunciation { get; private set; }

        internal readonly Dictionary<string, List<string>> _definition = new Dictionary<string, List<string>>();

        public Dictionary<string, List<string>> Definitions
        {
            get
            {
                return _definition;
            }
        }

        internal Dictionary<string, List<string>> Synonyms { get; }

        //internal string[] Translations { get; set; }  // доделать
        //internal string[] ReversoExamples { get; set; }  // доделать

        public WordCard()
        {
            Synonyms = new Dictionary<string, List<string>>();
            freeDictionaryApiObj = new FreeDictionaryApi();
        }

        public delegate void PrintDelegate(WordCard wordCardObj);

        public event PrintDelegate GetWordDelegate;

        /// <summary>
        /// Метод формирует единую объект слова на основе данных из разных API
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public WordCard FormWordCard(string searchQuery)
        {
            var wordObj = freeDictionaryApiObj.GetWordObject(searchQuery);

            if (wordObj != null)
            {
                Word = wordObj[0].Word;

                if (wordObj[0].Phonetic != null)
                {
                    Pronunciation = wordObj[0].Phonetic;
                }
                else
                {
                    Pronunciation = "No phonetic";  // заглушка
                }

                for (int i = 0; i < wordObj[0].Meanings.Count; i++)
                {
                    string partOfSpeech = wordObj[0].Meanings[i].PartOfSpeech;

                    // Add synonym per part of speech
                    if (!_definition.ContainsKey(partOfSpeech))
                    {
                        Synonyms.Add(partOfSpeech, wordObj[0].Meanings[i].Synonyms);
                    }
                    else
                    {
                        Synonyms[partOfSpeech].AddRange(wordObj[0].Meanings[i].Synonyms);
                    }

                    // Add defenitions per part of speech
                    if (!_definition.ContainsKey(partOfSpeech))
                    {
                        _definition.Add(partOfSpeech, new List<string>());
                    }
                    for (int j = 0; j < wordObj[0].Meanings[i].Definitions.Count; j++)
                    {
                        _definition[partOfSpeech]
                                .Add($@"{wordObj[0]
                                    .Meanings[i].Definitions[j].Definition}{"\n\t"}/{wordObj[0]
                                    .Meanings[i].Definitions[j].Example ?? "No example"}/ ");
                    }
                }
                return this;
            }
            else
            {
                return null;
            }
            
        }
    }
}
