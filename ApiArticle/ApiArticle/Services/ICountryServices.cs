using ApiArticle.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowThatCountryAPI.Services
{
    public interface IArticleServices
    {

        List<Article> GetAll( );

        Article GetByID( int id );
        
    }
}
