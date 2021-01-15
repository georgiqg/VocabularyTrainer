using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Article")]
        public string ArticleName { get; set; }

        [Required]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        [Required]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}