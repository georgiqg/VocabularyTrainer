namespace VocabularyTrainer.Models
{
    public class ExamWord
    {
        public string Singular { get; set; }
        public string Plural { get; set; }
        public string Article { get; set; }
        public string Meaning { get; set; }
        public bool CorrectAnswer { get; set; }
    }
}
