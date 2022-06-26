using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure.Data
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly DemoContext context;
        public CategoryRepository(DemoContext context)
        {
            this.context = context;
        }

        public List<Category> GetAll()
        {
            return context.Categories.Include(a => a.News).ToList();
        }

        public Category Get(int id)
        {
            return context.Categories.Include(a => a.News).First(a => a.CategoryId == id);
        }
        public void CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
