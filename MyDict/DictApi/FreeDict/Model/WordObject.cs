using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictApi.FeeDict.Model
{
    public class WordObject
    {
        public string Word { get; set; }

        public string Phonetic { get; set; }

        public List<Phonetics> Phonetics { get; set; }

        public List<Meanings> Meanings { get; set; }
    }
}
