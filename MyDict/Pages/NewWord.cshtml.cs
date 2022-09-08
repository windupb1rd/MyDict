using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDict.Model;

namespace MyDict.Pages
{
    public class NewWordModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!String.IsNullOrEmpty(Request.Form["searchField"]))
            {
                var word = new Word(Request.Form["searchField"]);
                var wordData = word.GetWordCardData();

                Console.WriteLine(wordData.Pronunciation);
            }
            
            
        }
    }
}
