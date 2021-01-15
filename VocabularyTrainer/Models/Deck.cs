using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class Deck
    {
        public int DeckId { get; set; }

        [StringLength(50)]
        [Display(Name = "Deck name")]
        public string DeckName { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public ICollection<Word> Words { get; set; }
    }
}
