using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.LanguageTests
{
    public class IndexModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public IndexModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IList<LanguageTest> LanguageTest { get;set; }

        public async Task OnGetAsync()
        {
            LanguageTest = await _context.LanguageTest
                .Include(l => l.Language)
                .Include(l => l.TestType).ToListAsync();
        }
    }
}
