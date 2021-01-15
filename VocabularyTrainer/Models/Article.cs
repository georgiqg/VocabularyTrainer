using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [StringLength(10)]
        [Display(Name = "Definte article")]
        public string DefiniteArticle { get; set; }

        [StringLength(10)]
        [Display(Name = "Indefinte article")]
        public string IndefiniteArticle { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}