using Electron.FactoryDP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Electron.FactoryDP.Report
{
    public class TxtReport : IReport
    {
        public string path { get; set; }
        public string type { get; set; }
    }
}