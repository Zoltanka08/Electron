using Electron.FactoryDP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.FactoryDP.Report
{
    public class XmlReport : IReport
    {
        public string path { get; set; }
        public string type { get; set; }
        public string title { get; set; }
    }
}