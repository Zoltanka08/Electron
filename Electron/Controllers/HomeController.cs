using AutoMapper;
using Electron.ViewModels;
using ElectronRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electron.Controllers
{
    public class HomeController : Controller
    {
        private IProductService productService;
        private const int startOfInterval = -60;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            var startDate = DateTime.Now.AddDays(startOfInterval);
            var recentProducts = this.productService.GetAllProducts().Where(m => m.data > startDate);
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(recentProducts);

            return View(productsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
