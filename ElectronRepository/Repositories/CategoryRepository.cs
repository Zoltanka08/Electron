using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class CategoryRepository : GenericRepository<ElectroShopEntities, Category>, ICategoryRepository
    {
        public int GetCategoryByName(string categoryName)
        {
            return base.Get(c => c.name.Equals(categoryName)).First().id;
        }

        public IEnumerable<Category> GetAll()
        {
            return base.Get();
        }
    }
}