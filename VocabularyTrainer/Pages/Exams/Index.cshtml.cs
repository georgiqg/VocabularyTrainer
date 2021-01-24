using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Exams
{
    public class IndexModel : PageModel
    {
        private readonly Data.VocabularyTrainerContext _context;

        public IndexModel(Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Language Language { get; set; }

        [BindProperty]
        public Deck Deck { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Language"] = new SelectList(_context.Language.Where(l => l.Decks.Any()), "LanguageId", "LanguageName");
            ViewData["Deck"] = new SelectList(_context.Deck.Where(d => 1 == 0), "DeckId", "DeckName"); // Empty collection

            return Page();
        }
    }
}
