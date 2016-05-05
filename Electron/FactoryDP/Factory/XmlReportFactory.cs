using Electron.FactoryDP.Interfaces;
using Electron.FactoryDP.Report;
using ElectronRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Electron.FactoryDP.Factory
{
    public class XmlReportFactory : IReportFactory 
    {
        public IReport GetReport(IEnumerable<ElectronRepository.Product> products)
        {
            const string filePath = @"C:\Users\Zoli\Documents\Visual Studio 2013\Projects\Electron\Electron\Products.xml";

            XmlReport txtReport = new XmlReport();
            txtReport.path = filePath;
            txtReport.type = "text/plain";
            txtReport.title = "Products Xml report";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            Services.Helpers.XmlWriter<Product>.WriteFile(products, filePath, txtReport.title);

            return txtReport;
        }
    }
}