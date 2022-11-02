using ApiArticle.Object;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace KnowThatCountryAPI.Services
{
    public class ArticleService: IArticleServices
    {
        List<Article> CountriesInfo;
        string bdinfo = "";
        public ArticleService()
        {
        }

        public List<Article> GetAll( )
        {
            return CountriesInfo;
        }

        public Article GetByID(int id )
        {
            return CountriesInfo[id];
        }
    }
}
