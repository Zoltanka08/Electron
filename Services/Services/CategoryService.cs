using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public int GetCategoryByName(string categoryName)
        {
            return this.categoryRepository.GetCategoryByName(categoryName);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }
    }
}