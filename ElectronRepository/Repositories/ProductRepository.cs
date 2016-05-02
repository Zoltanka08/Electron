using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class ProductRepository : GenericRepository<ElectroShopEntities, Product>, IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return base.Get();
        }

        public Product GetProductById(int id)
        {
            return base.Get(p => p.id == id).First();
        }

    }
}