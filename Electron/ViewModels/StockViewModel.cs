using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class StockViewModel
    {
        public int id { get; set; }
        public Nullable<int> cantity { get; set; }
        public Nullable<int> product_id { get; set; }
        public virtual ProductViewModel Product { get; set; }
    }
}