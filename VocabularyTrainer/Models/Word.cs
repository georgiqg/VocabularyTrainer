using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class Word
    {
        public int WordId { get; set; }

        [Required]
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        [Required]
        [StringLength(50)]
        public string Singular { get; set; }

        [StringLength(50)]
        public string Plural { get; set; }

        [Required]
        [StringLength(50)]
        public string Meaning { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}