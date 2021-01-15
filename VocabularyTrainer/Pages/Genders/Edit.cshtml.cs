using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Genders
{
    public class EditModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;
        private readonly IHtmlHelper htmlHelper;
        public List<SelectListItem> colors;

        public EditModel(VocabularyTrainerContext context, IHtmlHelper htmlHelper)
        {
            _context = context;

            this.htmlHelper = htmlHelper;
            colors = htmlHelper.GetEnumSelectList<GenderColor>()
                .Select(gc => new SelectListItem
                {
                    Value = gc.Text,
                    Text = gc.Text
                })
                .ToList();
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Gender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(Gender.GenderId))
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

        private bool GenderExists(int id)
        {
            return _context.Gender.Any(e => e.GenderId == id);
        }
    }
}
