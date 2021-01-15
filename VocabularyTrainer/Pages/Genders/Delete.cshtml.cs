using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Genders
{
    public class DeleteModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public DeleteModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gender Gender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gender = await _context.Gender.FirstOrDefaultAsync(m => m.GenderId == id);

            if (Gender == null)
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

            Gender = await _context.Gender.FindAsync(id);

            if (Gender != null)
            {
                _context.Gender.Remove(Gender);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
