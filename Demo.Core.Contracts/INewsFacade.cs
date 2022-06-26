using Demo.Core.Entities;
using System.Collections.Generic;

namespace Demo.Core.Contracts
{
    public interface INewsFacade
    {
        IEnumerable<News> GetHotteseNews(int count);
        IEnumerable<News> FindByCategory(int categoryId);
        IEnumerable<News> HomeSearch(string search);
        IEnumerable<News> GetAll();
        dynamic Text(int id);
        void CreateNews(News news);
        void Delete(int id);
    }
}
