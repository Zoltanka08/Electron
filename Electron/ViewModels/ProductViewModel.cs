using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<double> price { get; set; }
        public string brand { get; set; }
        public Nullable<int> rating { get; set; }
        public string description { get; set; }
        public Nullable<int> category_id { get; set; }
        public string image { get; set; }
        public string fileName { get; set; }
        public string categoryName { get; set; }

        public virtual CategoryViewModel Category { get; set; }
    }
}