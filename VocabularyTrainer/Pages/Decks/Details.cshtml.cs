using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Decks
{
    public class DetailsModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public DetailsModel(VocabularyTrainerContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
