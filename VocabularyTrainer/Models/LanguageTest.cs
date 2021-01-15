using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class LanguageTest
    {
        public int LanguageTestId { get; set; }
        public int TestTypeId { get; set; }
        public TestType TestType { get; set; }

        [Required]
        [MaxLength(50)]
        public string LanguageTestName { get; private set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<TestLog> TestLogs { get; set; }
    }
}
