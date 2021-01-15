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
    public class DeleteModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public DeleteModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LanguageTest LanguageTest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LanguageTest = await _context.LanguageTest
                .Include(l => l.Language)
                .Include(l => l.TestType).FirstOrDefaultAsync(m => m.LanguageTestId == id);

            if (LanguageTest == null)
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

            LanguageTest = await _context.LanguageTest.FindAsync(id);

            if (LanguageTest != null)
            {
                _context.LanguageTest.Remove(LanguageTest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
