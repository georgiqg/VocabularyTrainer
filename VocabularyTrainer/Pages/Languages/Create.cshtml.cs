using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Languages
{
    public class CreateModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;

        public List<SelectListItem> flags;

        public CreateModel(VocabularyTrainerContext context)
        {
            _context = context;

            // Get the list of files inside the wwwroot/images/flags directory:
            flags = Directory.GetFiles(@"wwwroot/images/flags", "*.jpg")
                .Select(f => new SelectListItem
                {
                    Value = f.Replace(@"\", "/").Replace("wwwroot", "~"),
                    Text = Path.GetFileNameWithoutExtension(f).Replace('_', ' ')
                })
                .ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Language Language { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Language.Add(Language);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
