using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure.Data
{
    public class NewsRepository: INewsRepository
    {
        private readonly DemoContext context;
        public NewsRepository(DemoContext context)
        {
            this.context = context;

        }
        public List<News> GetHotestNews(int count)
        {
            return context.News.OrderByDescending(a => a.PubDate).Take(count).ToList();
        }

        public List<News> HomeSearch(string search)
        {
            return context.News.Where
                (a => a.Title.Contains(search) || a.Summery.Contains(search)).ToList();
        }

        public News Get(int id)
        {
            return context.News.Find(id);
        }
        public List<News> FindByCategory(int categoryId)
        {
            return context.News.Include(a => a.Category)
                .Where(a => a.CategoryId == categoryId).ToList();
        }
        public List<News> GetAll()
        {
            return context.News.ToList();
        }
        public void CreateNews(News news)
        {
            context.Add(news);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.News.Remove(new News() { NewsId = id });
            context.SaveChanges();
        }
        public dynamic Text(int id)
        {
            return context.News.Find(id);
        }
    }
}
