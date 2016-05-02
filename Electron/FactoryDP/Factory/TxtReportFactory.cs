using Electron.FactoryDP.Interfaces;
using Electron.FactoryDP.Report;
using ElectronRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Electron.FactoryDP.Factory
{
    public class TxtReportFactory : IReportFactory
    {
        public IReport GetReport(IEnumerable<Product> products)
        {
            const string filePath = @"C:\Users\Zoli\Documents\Visual Studio 2013\Projects\Electron\Electron\Products.txt";

            TxtReport txtReport = new TxtReport();
            txtReport.path = filePath;
            txtReport.type = "text/plain";

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            Services.Helpers.TxtWriter<Product>.WriteFile(products,filePath);
            
            return txtReport;
        }
    }
}