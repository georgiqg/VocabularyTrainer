using Microsoft.EntityFrameworkCore;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Data
{
    public class VocabularyTrainerContext : DbContext
    {
        public VocabularyTrainerContext (DbContextOptions<VocabularyTrainerContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LanguageTest> LanguageTest { get; set; }
        public DbSet<TestLog> TestLog { get; set; }
        public DbSet<TestType> TestType { get; set; }
        public DbSet<Word> Word { get; set; }
    }
}
