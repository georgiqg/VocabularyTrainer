using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Languages
{
    public class IndexModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public IndexModel(VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IList<Language> Language { get;set; }

        public async Task OnGetAsync()
        {
            Language = await _context.Language.OrderBy(l => l.LanguageName).ToListAsync();
        }
    }
}
