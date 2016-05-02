using ElectronRepository.BaseRepository;
using ElectronRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronRepository.Repositories
{
    public class StockRepository : GenericRepository<ElectroShopEntities, Stock>, IStockRepository 
    {
        public IEnumerable<Stock> GetAllStock()
        {
            return base.Get();
        }
        public Stock GetById(int id)
        {
            return base.Get(s => s.id == id).First();
        }
    }
}