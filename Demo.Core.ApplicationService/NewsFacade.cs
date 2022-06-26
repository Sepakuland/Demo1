using Demo.Core.Contracts;
using Demo.Core.Entities;
using System;
using System.Collections.Generic;

namespace Demo.Core.ApplicationService
{
    public class NewsFacade: INewsFacade
    {
        INewsRepository newsReposiotry;
        public NewsFacade(INewsRepository newsReposiotry)
        {
            this.newsReposiotry = newsReposiotry;
        }

        public IEnumerable<News> GetHotteseNews(int count)
        {
            return newsReposiotry.GetHotestNews(count);
        }


        public IEnumerable<News> FindByCategory(int categoryId)
        {
            return newsReposiotry.FindByCategory(categoryId);
        }

        public IEnumerable<News> HomeSearch(string search)
        {
            return newsReposiotry.HomeSearch(search);
        }
        public IEnumerable<News> GetAll()
        {
            return newsReposiotry.GetAll();
        }
        public dynamic Text(int id)
        {
            return newsReposiotry.Text( id);
        }
        public void CreateNews(News news)
        {
            newsReposiotry.CreateNews( news);
        }
        public void Delete(int id)
        {
            newsReposiotry.Delete(id);
        }
    }
}
