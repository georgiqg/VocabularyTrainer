using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.TestTypes
{
    public class IndexModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public IndexModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IList<TestType> TestType { get;set; }

        public async Task OnGetAsync()
        {
            TestType = await _context.TestType.ToListAsync();
        }
    }
}
