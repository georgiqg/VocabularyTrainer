using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyTrainer.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocabularyTrainer.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly VocabularyTrainerContext _context;

        public ValuesController(VocabularyTrainerContext context)
        {
            _context = context;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{deckId}")]
        public SelectList GetArticlesByDeckId(int deckId)
        {
            var language = _context.Deck.FirstOrDefault(d => d.DeckId == deckId);
            if (language == null)
            {
                return null;
            }

            var articles = _context.Article.Where(a => a.LanguageId == language.LanguageId);
            var articlesList = new SelectList(articles, "ArticleId", "ArticleName");

            return articlesList;
        }
    }
}
