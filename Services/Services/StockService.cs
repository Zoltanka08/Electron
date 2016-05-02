using ElectronRepository;
using ElectronRepository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class StockService : IStockService
    {
        private IStockRepository stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public void UpdateProductStock(Stock stock)
        {
            stockRepository.Update(stock);
            stockRepository.Save();
        }

        public IEnumerable<Stock> GetAllStock()
        {
            return stockRepository.GetAllStock();
        }


        public void CreateStock(Stock stock)
        {
            this.stockRepository.Insert(stock);
            this.stockRepository.Save();
        }


        public Stock GetById(int id)
        {
            return this.stockRepository.GetById(id);
        }


        public void DeleteStock(Stock stock)
        {
            this.stockRepository.Delete(stock);
            stockRepository.Save();
        }

    }
}