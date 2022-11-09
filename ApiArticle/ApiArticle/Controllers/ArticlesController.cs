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
                        Article item = new Article(myReader.GetInt32(0), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3));
                        Console.WriteLine(item.name);
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

        [HttpPost("getarticle")]
        public Article GetArticle([FromBody] Article item1)
        {
            Article article = new Article(1, "", "", "");
            MySqlConnection databaseCon = new MySqlConnection(_config.GetConnectionString("BdConnexion"));

            MySqlCommand commandDataBase = new MySqlCommand("SELECT * FROM articles WHERE name = @name ", databaseCon);

            commandDataBase.Parameters.AddWithValue("@name", item1.name);
            commandDataBase.CommandTimeout = 60;

            try
            {
                databaseCon.Open();

                MySqlDataReader myReader = commandDataBase.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        Article item = new Article(myReader.GetInt32(0), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3));
                        Console.WriteLine(item.name);
                        article = item;
                    }
                }
            }
            catch (Exception e)
            {

            }
            List<string> strings = new List<string>();
            strings.Add("oui");
            return article;
        }

        [HttpPost]
        public bool Add([FromBody]Article item1)
        {
           MySqlConnection databaseCon = new MySqlConnection(_config.GetConnectionString("BdConnexion"));

            Console.WriteLine("ca marche1");
            MySqlCommand commandDataBase = new MySqlCommand("INSERT INTO articles (id,name,text,autor) VALUES (@id,@name,@text,@autor) ", databaseCon);

            commandDataBase.Parameters.AddWithValue("@id", 1);
            commandDataBase.Parameters.AddWithValue("@name", item1.name);
            commandDataBase.Parameters.AddWithValue("@text", item1.text);
            commandDataBase.Parameters.AddWithValue("@autor", item1.autor);

            Console.WriteLine("ca marche2");

            Console.WriteLine("ca marche");

            commandDataBase.CommandTimeout = 60;

            try
            {
                databaseCon.Open();

                commandDataBase.ExecuteNonQuery();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        [HttpPost("update")]
        public bool Update([FromBody] Article item1)
        {
            MySqlConnection databaseCon = new MySqlConnection(_config.GetConnectionString("BdConnexion"));

            MySqlCommand commandDataBase = new MySqlCommand("UPDATE articles SET text = @text, autor = @autor WHERE name = @name ", databaseCon);

            commandDataBase.Parameters.AddWithValue("@name", item1.name);
            commandDataBase.Parameters.AddWithValue("@text", item1.text);
            commandDataBase.Parameters.AddWithValue("@autor", item1.autor);

            commandDataBase.CommandTimeout = 60;

            try
            {
                databaseCon.Open();

                commandDataBase.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost("delete")]
        public bool Delete([FromBody] Article item1)
        {
            MySqlConnection databaseCon = new MySqlConnection(_config.GetConnectionString("BdConnexion"));

            MySqlCommand commandDataBase = new MySqlCommand("DELETE FROM  articles where name = @name ", databaseCon);

            commandDataBase.Parameters.AddWithValue("@name", item1.name);

            commandDataBase.CommandTimeout = 60;

            try
            {
                databaseCon.Open();

                commandDataBase.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}