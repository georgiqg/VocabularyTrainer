using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Words
{
    public class CreateModel : PageModel
    {
        private readonly Data.VocabularyTrainerContext _context;

        public CreateModel(Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ArticleId"] = new SelectList(_context.Article, "ArticleId", "ArticleName");
            ViewData["DeckId"] = new SelectList(_context.Deck, "DeckId", "DeckName");
            return Page();
        }

        [BindProperty]
        public Word Word { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Word.Add(Word);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
