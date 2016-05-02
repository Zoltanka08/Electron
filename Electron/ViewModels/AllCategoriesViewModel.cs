using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class AllCategoriesViewModel
    {
        public int id { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> CategoryItem { get; set; }
    }
}