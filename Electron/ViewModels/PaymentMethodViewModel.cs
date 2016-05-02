using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class PaymentMethodViewModel
    {
        public int id { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> MethodItems { get; set; }

    }
}