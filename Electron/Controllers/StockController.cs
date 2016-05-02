using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Services.Interfaces;
using ElectronRepository;
using Electron.ViewModels;
using Electron.CustomAttributes;

namespace Electron.Controllers
{
    [UserAuthorize(Roles="furnizor")]
    public class StockController : Controller
    {
        private IProductService productService;
        private IStockService stockService;

        public StockController(IProductService productService, IStockService stockService)
        {
            this.stockService = stockService;
            this.productService = productService;
        }

        public ActionResult Index()
        {
            IEnumerable<Stock> stocks = this.stockService.GetAllStock();
            Mapper.CreateMap<Stock, StockViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            var stockModel = Mapper.Map<IEnumerable<Stock>, IEnumerable<StockViewModel>>(stocks);
            
            return View(stockModel);
        }


        public ActionResult Edit(int id)
        {
            var model = this.stockService.GetById(id);
            Mapper.CreateMap<Stock, StockViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            var stockModel = Mapper.Map<Stock, StockViewModel>(model);
            return View(stockModel);
        }

        [HttpPost]
        public ActionResult Edit(StockViewModel model)
        {
            if (ModelState.IsValid)
            {
                var stock = this.stockService.GetById(model.id);
                stock.cantity = model.cantity;
                this.stockService.UpdateProductStock(stock);
                return RedirectToAction("Index", "Stock");
            }

            return View(model);
        }

    }
}
