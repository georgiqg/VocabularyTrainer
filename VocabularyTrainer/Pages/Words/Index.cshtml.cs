using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Words
{
    public class IndexModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public IndexModel(VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IList<Word> Word { get;set; }

        public async Task OnGetAsync()
        {
            Word = await _context.Word.ToListAsync();
        }
    }
}
