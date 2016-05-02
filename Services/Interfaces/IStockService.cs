using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStockService
    {
        void UpdateProductStock(Stock stock);
        IEnumerable<Stock> GetAllStock();
        void CreateStock(Stock stock);
        Stock GetById(int id);
        void DeleteStock(Stock stock);
    }
}
