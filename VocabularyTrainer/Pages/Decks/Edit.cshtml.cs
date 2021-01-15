using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Decks
{
    public class EditModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public EditModel(VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Deck Deck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deck = await _context.Deck
                .Include(d => d.Language).FirstOrDefaultAsync(m => m.DeckId == id);

            if (Deck == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "LanguageName").OrderBy(l => l.Text);
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

            _context.Attach(Deck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(Deck.DeckId))
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

        private bool DeckExists(int id)
        {
            return _context.Deck.Any(e => e.DeckId == id);
        }
    }
}
