using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class Language
    {
        public int LanguageId { get; set; }

        [StringLength(50)]
        public string LanguageName { get; set; }

        // Flags downloaded from https://www.sciencekids.co.nz/pictures/flags.html
        [StringLength(50)]
        public string FlagUrl { get; set; }

        public ICollection<Deck> Decks { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<LanguageTest> LanguageTests { get; set; }
    }
}
