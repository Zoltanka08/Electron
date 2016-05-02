using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronRepository.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAllStock();
        void Update(Stock stock);
        void Insert(Stock stock);
        Stock GetById(int id);
        void Delete(Stock stock);
        void Save();
    }
}
