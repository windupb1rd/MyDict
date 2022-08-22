using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace DictApi
{
    internal class StringDownloader
    {
        public string GetString(string url)
        {
            WebClient client = new()
            {
                Encoding = Encoding.UTF8
            };

            try
            {
                string response = client.DownloadString(url);
                return response;
            }
            catch (WebException)
            {
                Console.WriteLine("I couldn't find the word. Check you query for typos or try looking for another word.");

                return null;
            }
        }
    }
}