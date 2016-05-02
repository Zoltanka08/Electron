using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Electron.FactoryDP.Interfaces
{
    public interface IReportFactory
    {
        IReport GetReport(IEnumerable<Product> products);
    }
}
