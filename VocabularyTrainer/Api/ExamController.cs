using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VocabularyTrainer.Data;
using VocabularyTrainer.Models;

namespace VocabularyTrainer.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly VocabularyTrainerContext _context;

        public ExamController(VocabularyTrainerContext context)
        {
            _context = context;
        }

        // GET api/exam/GetVocabularyExam/1
        [HttpGet("{deckIds}")]
        public IEnumerable<ExamWord> GetVocabularyExam(string deckIds)
        {
            var decks = deckIds.Split('|');

            // Use a random value for the ID in order to return the list in random order
            var random = new Random();

            var words = _context.Word
                .Where(w => decks.Contains(w.DeckId.ToString()))
                .Select(w => new ExamWord
                {
                    ExamWordId = random.Next(ushort.MinValue, ushort.MaxValue), // 0 to 65,535
                    Singular = w.Singular,
                    Plural = w.Plural,
                    Article = w.Article.ArticleName,
                    Meaning = w.Meaning,
                    CorrectAnswer = false
                });

            return words.OrderBy(w => w.ExamWordId).ToList();
        }
    }
}
