using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electron.FactoryDP.Interfaces
{
    public interface IReport
    {
        string path { get; set; }
        string type { get; set; }
    }
}
