using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyDict.Pages
{
    public class TextInputModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine(Request.Form["userInput"]);
        }
    }
}
