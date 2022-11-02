using ApiArticle.Object;
using KnowThatCountryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ApiArticle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        //services
        IArticleServices _articleServices;
        IConfiguration _config;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ArticlesController> _logger;

        public ArticlesController(ILogger<ArticlesController> logger, IArticleServices articleServices, IConfiguration config)
        {
            _logger = logger;
            _articleServices = articleServices;
            _config = config;
        }


        [HttpGet]
        public IEnumerable<Article> Get()
        {
            List<Article> articles = new List<Article>();
            MySqlConnection databaseCon = new MySqlConnection(_config.GetConnectionString("BdConnexion"));

            MySqlCommand commandDataBase = new MySqlCommand("SELECT * FROM articles", databaseCon);
            commandDataBase.CommandTimeout = 60;

            try
            {
                databaseCon.Open();

                MySqlDataReader myReader = commandDataBase.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        Article item = new Article(myReader.GetString(0), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3));
                        Console.WriteLine(item.Name);
                        articles.Add(item);
                    }
                }
            }
            catch(Exception e)
            {

            }
            List<string> strings = new List<string>();
            strings.Add("oui");
            return articles;
        }
    }
}