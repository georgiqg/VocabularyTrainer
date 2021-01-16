using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Decks
{
    public class IndexModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public IndexModel(VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IList<Deck> Deck { get;set; }

        public async Task OnGetAsync()
        {
            Deck = await _context.Deck
                .Include(d => d.Language).ToListAsync();
        }
    }
}
