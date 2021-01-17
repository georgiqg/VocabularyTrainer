using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var words = _context.Word
                .Where(w => decks.Contains(w.DeckId.ToString()))
                .Select(w => new ExamWord
                {
                    Singular = w.Singular,
                    Plural = w.Plural,
                    Article = w.Article.ArticleName,
                    Meaning = w.Meaning,
                    CorrectAnswer = false
                })
                .ToList();

            return words;
        }
    }
}
