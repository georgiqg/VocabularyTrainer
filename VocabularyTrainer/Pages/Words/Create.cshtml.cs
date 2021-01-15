﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Pages.Words
{
    public class CreateModel : PageModel
    {
        private readonly VocabularyTrainer.Data.VocabularyTrainerContext _context;

        public CreateModel(VocabularyTrainer.Data.VocabularyTrainerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Word Word { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Word.Add(Word);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
