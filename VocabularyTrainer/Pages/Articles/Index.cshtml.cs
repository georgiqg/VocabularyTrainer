using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public IndexModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article
                .Include(a => a.Gender)
                .Include(a => a.Language).ToListAsync();
        }
    }
}
