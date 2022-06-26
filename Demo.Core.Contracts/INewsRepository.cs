using Demo.Core.Entities;
using System;
using System.Collections.Generic;

namespace Demo.Core.Contracts
{
    public interface INewsRepository
    {
        List<News> GetHotestNews(int count);
        List<News> HomeSearch(string search);
        News Get(int id);
        List<News> FindByCategory(int categoryId);
        List<News> GetAll();
        void CreateNews(News news);
        void Delete(int id);
        dynamic Text(int id);
    }
}
