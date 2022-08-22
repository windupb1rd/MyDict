using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyDict.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var w = new Word("hi");
            var w1 = new Word("run");
            //w.PrintWord();
            w.CreateCard();
            w1.CreateCard();
            w.DeleteWord();
            w1.DeleteWord();
        }
    }
}