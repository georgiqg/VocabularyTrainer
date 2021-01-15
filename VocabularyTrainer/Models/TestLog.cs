using System.ComponentModel.DataAnnotations.Schema;

namespace VocabularyTrainer.Models
{
    public class TestLog
    {
        public int TestLogId { get; set; }
        public int WordsCount { get; set; }
        public int RightAnswers { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Accuracy { get; private set; }

        public int LanguageTestId { get; set; }
        public LanguageTest LanguageTest { get; set; }

        public void SetAccuracy()
        {
            Accuracy = WordsCount == 0 ? 0 : (RightAnswers / WordsCount) * 100;
        }
    }
}
