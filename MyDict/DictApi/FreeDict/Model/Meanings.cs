using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictApi.FeeDict.Model
{
    public class Meanings
    {
        public string PartOfSpeech { get; set; }

        public List<string> Synonyms { get; set; }

        public List<Definitions> Definitions { get; set; }
    }
}
