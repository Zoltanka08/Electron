
using ElectronRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class ChitantaViewModel
    {
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}