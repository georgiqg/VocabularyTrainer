using System.Collections.Generic;
using System.ComponentModel;

namespace VocabularyTrainer.Models
{
    public class LanguageTest
    {
        public int LanguageTestId { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int TestTypeId { get; set; }

        [DisplayName("Test Type")]
        public TestType TestType { get; set; }

        public ICollection<TestLog> TestLogs { get; set; }
    }
}
