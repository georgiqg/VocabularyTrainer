using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VocabularyTrainer.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocabularyTrainer.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly VocabularyTrainerContext _context;

        public ValuesController(VocabularyTrainerContext context)
        {
            _context = context;
        }

        // GET api/values/GetArticlesByDeckId/5
        [HttpGet("{deckId}")]
        public SelectList GetArticlesByDeckId(int deckId)
        {
            var language = _context.Deck.FirstOrDefault(d => d.DeckId == deckId);
            if (language == null)
            {
                return null;
            }

            var articles = _context.Article
                .Where(a => a.LanguageId == language.LanguageId)
                .OrderBy(a => a.ArticleId);

            return new SelectList(articles, "ArticleId", "ArticleName");
        }

        // GET api/values/GetDecksByLanguageId/1
        [HttpGet("{languageId}")]
        public SelectList GetDecksByLanguageId(int languageId)
        {
            var decks = _context.Deck
                .Where(d => d.LanguageId == languageId)
                .OrderBy(d => d.DeckName);

            return new SelectList(decks, "DeckId", "DeckName");
        }

        // GET api/values/GetTestTypesByLanguageId/1
        [HttpGet("{languageId}")]
        public SelectList GetTestTypesByLanguageId(int languageId)
        {
            var testTypes = _context.LanguageTest
                .Include(lt => lt.TestType)
                .Where(lt => lt.LanguageId == languageId)
                .OrderBy(lt => lt.TestTypeId);

            return new SelectList(testTypes, "LanguageTestId", "TestType.TestTypeName");
        }

    }
}
