using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class TestType
    {
        //Vocabulary = 1,
        //Gender = 2,
        //Plural = 3
        public int TestTypeId { get; set; }

        [Required]
        public string TestTypeName { get; set; }
    }
}
