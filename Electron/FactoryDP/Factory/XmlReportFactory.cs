using Electron.FactoryDP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.FactoryDP.Factory
{
    public class XmlReportFactory : IReportFactory 
    {
        public IReport GetReport(IEnumerable<ElectronRepository.Product> products)
        {
            throw new NotImplementedException();
        }
    }
}