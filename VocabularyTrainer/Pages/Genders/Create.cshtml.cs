﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Genders
{
    public class CreateModel : PageModel
    {
        private readonly VocabularyTrainerContext _context;
        private readonly IHtmlHelper htmlHelper;
        public List<SelectListItem> colors;

        public CreateModel(VocabularyTrainerContext context, IHtmlHelper htmlHelper)
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Gender Gender { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Gender.Add(Gender);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
