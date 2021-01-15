using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public partial class Gender
    {
        public int GenderId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Gender Name")]
        public string GenderName { get; set; }

        [StringLength(50)]
        [DisplayName("Gender Color")]
        public string GenderColor { get; set; }
    }
}