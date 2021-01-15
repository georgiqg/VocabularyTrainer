using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.LanguageTests
{
    public class EditModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public EditModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
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
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "LanguageName").OrderBy(l => l.Text);
            ViewData["TestTypeId"] = new SelectList(_context.TestType, "TestTypeId", "TestTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LanguageTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageTestExists(LanguageTest.LanguageTestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LanguageTestExists(int id)
        {
            return _context.LanguageTest.Any(e => e.LanguageTestId == id);
        }
    }
}
