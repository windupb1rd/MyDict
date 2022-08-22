using DictApi.FeeDict.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictApi.FreeDict
{
    internal class FreeDictionaryApi
    {
        public List<WordObject> GetWordObject(string query)
        {
            string url = "https://api.dictionaryapi.dev/api/v2/entries/en/" + query;

            List<WordObject> wordObject = null;
            var sd = new StringDownloader();
            string? stringValue = sd.GetString(url);

            if (stringValue != null)
                wordObject = JsonConvert.DeserializeObject<List<WordObject>>(stringValue);

            return wordObject;
        }
    }
}
