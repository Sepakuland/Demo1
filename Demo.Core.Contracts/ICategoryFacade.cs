using Demo.Core.Entities;
using System.Collections.Generic;

namespace Demo.Core.Contracts
{
    public interface ICategoryFacade
    {
        IEnumerable<Category> GetAll();
        void CreateCategory(Category category);
    }
}
