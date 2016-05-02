using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Interfaces;
using Services.Services;
using Electron.DependencyInjection;
using Electron.Controllers;
using ElectronRepository.Interfaces;
using ElectronRepository.Repositories;
using Electron.CustomAttributes;


namespace Electron.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            ContainerBootstrap.RegisterTypes(container);
            container.
                RegisterType<UserController>().
                RegisterType<IUserService, UserService>();
            container.
                RegisterType<MyAccountController>().
                RegisterType<IUserService, UserService>();
            container.
                RegisterType<UserAuthorizeAttribute>().
                RegisterType<IUserService, UserService>();
            container.
                RegisterType<StockController>().
                RegisterType<IStockService, StockService>().
                RegisterType<IProductService, ProductService>();
            container.
                RegisterType<HomeController>().
                RegisterType<IProductService, ProductService>();
            container.
                RegisterType<ProductController>().
                RegisterType<IProductService, ProductService>().
                RegisterType<IStockService,StockService>().
                RegisterType<ICategoryService,CategoryService>();;
            container.
                RegisterType<OrderController>().
                RegisterType<IOrderService, OrderService>().
                RegisterType<IProductService,ProductService>().
                RegisterType<IStockService, StockService>().
                RegisterType<IPaymentMethodService, PaymentMethodService>().
                RegisterType<IUserService,UserService>();
            container.
                RegisterType<CategoryService>().
                RegisterType<ICategoryRepository, CategoryRepository>();

            
        }
         
    }
}