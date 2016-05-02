using Electron.FactoryDP.Factory;
using Electron.FactoryDP.Interfaces;
using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.FactoryDP.Assembler
{
    public class ReportAssembler
    {
        IReportFactory reportFactory;

        public ReportAssembler(string reportTypeName)
        {
            if (reportTypeName.Equals("txt"))
            {
                this.reportFactory = new TxtReportFactory();
            }
            else
                if (reportTypeName.Equals("xml"))
                {
                    this.reportFactory = new XmlReportFactory();
                }
                else
                {
                    this.reportFactory = new NullReportFactory();
                }
        }

        public IReport AssembleReport(IEnumerable<Product> products)
        {
            return reportFactory.GetReport(products);
        }
    }
}