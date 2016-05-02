
using ElectronRepository.Interfaces;
using ElectronRepository.Repositories;
using Microsoft.Practices.Unity;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.DependencyInjection
{
    public class ContainerBootstrap
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository,UserRepository>();
            container.RegisterType<IStockService, StockService>();
            container.RegisterType<IStockRepository, StockRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IPaymentMethodRepository, PaymentMethodRepository>();
            container.RegisterType<IPaymentMethodService, PaymentMethodService>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryService, CategoryService>();

        }
    }
}