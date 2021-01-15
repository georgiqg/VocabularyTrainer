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
    public class DeleteModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public DeleteModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TestType TestType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestType = await _context.TestType.FirstOrDefaultAsync(m => m.TestTypeId == id);

            if (TestType == null)
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

            TestType = await _context.TestType.FindAsync(id);

            if (TestType != null)
            {
                _context.TestType.Remove(TestType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
