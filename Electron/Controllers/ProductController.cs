using AutoMapper;
using Electron.ViewModels;
using ElectronRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using Electron.FactoryDP.Assembler;
using Electron.FactoryDP.Interfaces;

namespace Electron.Controllers
{
    public class ProductController : Controller
    {

        private IProductService productService;
        private IStockService stockService;
        private ICategoryService categoryService;

        public ProductController(IProductService productService, IStockService stockService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.stockService = stockService;
            this.categoryService = categoryService;
        }

        public ActionResult Index(int? product_id, int? category_id, string brandName, string interval, string productName, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IEnumerable<Product> products = null;
            if (product_id != null)
            {
                products = this.productService.GetAllProducts().Where(p => p.id == product_id);
            }
            else
                if (category_id == null)
                {
                    if (brandName == null)
                    {
                        if (interval == null)
                        {
                            if (productName == null)
                                products = this.productService.GetAllProducts();
                            else
                            {
                                products = this.productService.GetAllProducts().Where(p => p.brand.Contains(productName));
                            }
                        }
                        else
                        {
                            string[] captions = interval.Split('-');
                            if (captions[0].Equals("over"))
                            {
                                var b = Int32.Parse(captions[1]);
                                products = this.productService.GetAllProducts().Where(p => p.price >= b);
                            }
                            else
                            {
                                int a = Int32.Parse(captions[0]);
                                int b = Int32.Parse(captions[1]);
                                products = this.productService.GetAllProducts().Where(p => p.price >= a && p.price < b);
                            }
                        }
                    }
                    else
                    {
                        products = this.productService.GetAllProducts().Where(p => p.name.Equals(brandName));
                    }
                }
                else
                {
                    products = this.productService.GetAllProducts().Where(p => p.category_id == category_id);
                }

            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            var productsViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products).ToList();
            ViewBag.Products = productsViewModel;

            var productPageList = productsViewModel.ToPagedList(pageIndex, pageSize);

            ViewBag.isAdmin = false;
            if (Request.IsAuthenticated)
            {
                ViewBag.isAdmin = User.IsInRole("admin");
            }

            var categories = categoryService.GetAll();

            ICollection<string> brands = new List<string>();

            var pr = this.productService.GetAllProducts();

            foreach (var prod in pr)
            {
                if (!brands.Contains(prod.name))
                {
                    brands.Add(prod.name);
                }
            }

            ICollection<String> costs = new List<string>();
            costs.Add("1-100");
            costs.Add("101-200");
            costs.Add("201-300");
            costs.Add("301-500");
            costs.Add("501-1000");
            costs.Add("1001-2000");
            costs.Add("2001-3000");
            costs.Add("over-3000");

            ViewBag.categories = categories;
            ViewBag.brands = brands;
            ViewBag.costs = costs;
            

            return View(productPageList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && ModelState.IsValid)
            {
                var allCategories = categoryService.GetAll();
                var categoriName = new List<string>();

                foreach (var category in allCategories)
                {
                    categoriName.Add(category.name);
                }


                int categoriId = 0;
                if (categoriName.Contains(model.categoryName))
                {
                    categoriId = this.categoryService.GetCategoryByName(model.categoryName);
                }
                else
                {
                    model.Category = new CategoryViewModel();
                    model.Category.name = model.categoryName;
                }

                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("../Images/"), fileName);
                file.SaveAs(path);
                model.image = path;
                model.fileName = fileName;
                model.category_id = categoriId;
                Mapper.CreateMap<ProductViewModel, Product>();
                Mapper.CreateMap<CategoryViewModel, Category>();
                var product = Mapper.Map<ProductViewModel, Product>(model);
                //product.category_id = model.category_id;
                this.productService.InsertProduct(product);

                Stock stock = new Stock();
                //stock.product_id = model.id;
                stock.cantity = 0;
                this.stockService.CreateStock(stock);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Invalid data!");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var product = this.productService.GetProductById(id);
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            var model = Mapper.Map<Product, ProductViewModel>(product);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(ProductViewModel model, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && ModelState.IsValid)
            {
                var fileName = Path.GetFileName(file.FileName);
                string path2 = Path.Combine(Server.MapPath("../"));
                string path3 = Directory.GetParent(path2).FullName;
                string currentDir = Directory.GetParent(path3).FullName;
                string filePath = currentDir + "\\Images\\" + fileName;
                file.SaveAs(filePath);
                model.image = filePath;
                model.fileName = fileName;
                Mapper.CreateMap<ProductViewModel, Product>();
                Mapper.CreateMap<CategoryViewModel, Product>();
                var product = Mapper.Map<ProductViewModel, Product>(model);
                this.productService.UpdateProduct(product);
                return RedirectToAction("Index", "Product");
            }
            else
                if (file == null && ModelState.IsValid)
                {
                    var product = this.productService.GetProductById(model.id);
                    string fName = product.fileName;
                    string path = product.image;
                    model.fileName = fName;
                    model.image = path;
                    Mapper.CreateMap<ProductViewModel, Product>();
                    Mapper.CreateMap<CategoryViewModel, Product>();
                    var productUpdate = Mapper.Map<ProductViewModel, Product>(model);
                    this.productService.UpdateProduct(productUpdate);
                    return RedirectToAction("Index", "Product");
                }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = this.productService.GetProductById(id);
            Stock stock = this.stockService.GetAllStock().Where(p => p.product_id == id).First();
            this.stockService.DeleteStock(stock);
            this.productService.DeleteProduct(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpDelete]
        public ActionResult Index(int id, string foo)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var product = this.productService.GetProductById(id);
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
            var model = Mapper.Map<Product, ProductViewModel>(product);
            return View(model);
        }

        public ActionResult Report()
        {
            List<SelectListItem> items = GetSelectListForReportType();
            ViewBag.ReportType = items;
            return View();
        }

        [HttpPost]
        public ActionResult Report(string ReportType = null)
        {
            ReportAssembler reportAssembler = new ReportAssembler(ReportType);
            IReport report = reportAssembler.AssembleReport(productService.GetAllProducts());

            return File(report.path, report.type);
        }

        private List<SelectListItem> GetSelectListForReportType()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "txt",
                    Text = "Text Report",
                    Selected = true
                },
                new SelectListItem()
                {
                    Value = "xml",
                    Text = "Xml Report",
                    Selected = false
                }
            };
            
            return items;
        }
    }
}
