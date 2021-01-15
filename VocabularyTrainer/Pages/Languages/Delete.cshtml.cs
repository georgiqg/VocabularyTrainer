using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Languages
{
    public class DeleteModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public DeleteModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Language Language { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Language = await _context.Language.FirstOrDefaultAsync(m => m.LanguageId == id);

            if (Language == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Language = await _context.Language.FindAsync(id);

            if (Language != null)
            {
                _context.Language.Remove(Language);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
