using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Words
{
    public class EditModel : PageModel
    {
        private readonly Data.VocabularyTrainerContext _context;

        public EditModel(Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Word Word { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Word = await _context.Word
                .Include(w => w.Article)
                .Include(w => w.Deck).FirstOrDefaultAsync(m => m.WordId == id);

            if (Word == null)
            {
                return NotFound();
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "ArticleId", "ArticleName");
            ViewData["DeckId"] = new SelectList(_context.Deck, "DeckId", "DeckName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(Word.WordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WordExists(int id)
        {
            return _context.Word.Any(e => e.WordId == id);
        }
    }
}
