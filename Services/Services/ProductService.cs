using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return this.productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return this.productRepository.GetAllProducts().First(p => p.id == id);
        }

        public void InsertProduct(Product product)
        {
            this.productRepository.Insert(product);
            this.productRepository.Save();
        }

        public void DeleteProduct(Product product)
        {
            this.productRepository.Delete(product);
            this.productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            this.productRepository.Update(product);
            this.productRepository.Save();
        }
    }
}