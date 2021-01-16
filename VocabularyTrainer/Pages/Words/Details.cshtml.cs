using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Words
{
    public class DetailsModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public DetailsModel(VocabularyTrainerContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
