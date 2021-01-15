using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.LanguageTests
{
    public class CreateModel : PageModel
    {
        private readonly Data.VocabularyTrainerContext _context;

        public CreateModel(Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "LanguageName").OrderBy(l => l.Text);
            ViewData["TestTypeId"] = new SelectList(_context.TestType, "TestTypeId", "TestTypeName");
            return Page();
        }

        [BindProperty]
        public LanguageTest LanguageTest { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LanguageTest.Add(LanguageTest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
