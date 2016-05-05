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
    public class OrderController : Controller
    {
        private IProductService productService;
        private IOrderService orderService;
        private IStockService stockService;
        private IPaymentMethodService paymentMethodService;
        private IUserService userService;

        public OrderController(IProductService productService, IOrderService orderService,
            IStockService stockService, IPaymentMethodService paymentMethodService, IUserService userService)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.stockService = stockService;
            this.paymentMethodService = paymentMethodService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var user = this.userService.GetByUsername(User.Identity.Name);
            var orders = this.orderService.getOrdersByUserId(user.id).Where(o => o.OrderState.state.Equals("Unconfirmed") || o.OrderState.state.Equals("Not Finalized"));
            Mapper.CreateMap<Order, OrderViewModel>();

            var orderView = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return View(orderView);
        }

        public ActionResult AddToCart(int product_id)
        {
            var user = this.userService.GetByUsername(User.Identity.Name);
            Order order = new Order();
            order.order_state_id = 1001;
            order.product_id = product_id;
            order.user_id = this.userService.GetByUsername(User.Identity.Name).id;
            order.data = DateTime.Now;
            this.orderService.InsertOrder(order);

            return RedirectToAction("Index", "Product");
        }

        public ActionResult AllOrders(int id)
        {
            var orders = this.orderService.getOrdersByUserId(id).Where(o => !o.OrderState.state.Equals("Not Finalized"));
            Mapper.CreateMap<Order, OrderViewModel>();
            var orderView = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return View(orderView);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var order = this.orderService.GetOrderById(id);
            this.orderService.DeleteOrder(order);
            return RedirectToAction("Index", "Order");
        }

        public ActionResult Confirm(int order_id, int user_id)
        {
            var order = this.orderService.GetOrderById(order_id);

            var stocks = this.stockService.GetAllStock().Where(s => s.product_id == order.Product.id).ToList();

            foreach (var stock in stocks)
            {
                if (stock.cantity > 0)
                {
                    order.order_state_id = 0;
                    stock.cantity--;
                    this.orderService.UpdateOrder(order);
                    return RedirectToAction("AllOrders", "Order", new { id = user_id });
                }
                else
                {
                    ModelState.AddModelError("ZeroCantity", "There is no product in stock!");
                }
            }

            return RedirectToAction("AllOrders", "Order", new { id = user_id });
        }

        public ActionResult Unconfirm(int order_id, int user_id)
        {
            var order = this.orderService.GetOrderById(order_id);
            order.order_state_id = 1;

            var stocks = this.stockService.GetAllStock().Where(s => s.product_id == order.Product.id).ToList();

            foreach (var stock in stocks)
            {
                stock.cantity++;
            }

            this.orderService.UpdateOrder(order);

            return RedirectToAction("AllOrders", "Order", new { id = user_id });
        }

        public ActionResult Finalize()
        {

            var user = this.userService.GetByUsername(User.Identity.Name);

            if (user.IBAN != null)
            {
                ViewBag.IBAN = user.IBAN;
            }

            PaymentMethodViewModel model = new PaymentMethodViewModel();
            model.MethodItems = getPaymentList();

            return View(model);
        }

        private List<SelectListItem> getPaymentList()
        {
            var methods = this.paymentMethodService.getAllMethods();
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem listItem = new SelectListItem { Text = "Select a method", Value = "-1", Selected = true };
            list.Add(listItem);
            foreach (var item in methods)
            {
                listItem = new SelectListItem { Text = item.method.ToString(), Value = item.id.ToString() };
                list.Add(listItem);
            }

            return list;
        }

        [HttpPost]
        public ActionResult Finalize(FormCollection formCollection)
        {

            var value = formCollection["id"];
            var text = formCollection["hidText"];

            var user = this.userService.GetByUsername(User.Identity.Name);
            if (text.Equals("CreditCard"))
            {
                if (user.IBAN == null)
                {
                    ModelState.AddModelError("NoIBAN", "IBAN is required");
                    PaymentMethodViewModel model = new PaymentMethodViewModel();
                    model.MethodItems = getPaymentList();

                    return View(model);
                }
            }

            var orders = this.orderService.getOrdersByUserId(user.id).Where(o => o.OrderState.state.Equals("Not Finalized"));
            var chitanta = new ChitantaViewModel();
            chitanta.User = user;
            chitanta.Products = new List<Product>();
            foreach (var order in orders)
            {
                order.order_state_id = 1;
                order.payment_id = Int32.Parse(value);
                this.orderService.UpdateOrder(order);

                if (order.bargain != null)
                    order.Product.price = order.bargain;
                chitanta.Products.Add(order.Product);
            }

            return View("Chitanta", chitanta);
        }

        public ActionResult Bargain(int id)
        {
            Order order = orderService.GetOrderById(id);
            Mapper.CreateMap<Order, OrderViewModel>();
            var orderView = Mapper.Map<Order, OrderViewModel>(order);

            return View(orderView);
        }

        [HttpPost]
        public ActionResult Bargain(OrderViewModel model)
        {
            Order order = orderService.GetOrderById(model.id);
            order.bargain = model.bargain;

            orderService.UpdateOrder(order);

            return RedirectToAction("Index", "Order");
        }

    }
}
