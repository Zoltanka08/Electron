using ElectronRepository;
using ElectronRepository.Repositories;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Electron.CustomAttributes
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private IUserService userService;

        public UserAuthorizeAttribute()
        {
            InitializeService(userService);
        }

        public void InitializeService(IUserService userService)
        {
            if(this.userService == null)
                this.userService = new UserService(new UserRepository());
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User user = userService.GetByUsername(HttpContext.Current.User.Identity.Name);
            if (string.IsNullOrEmpty(base.Roles))
                return true;

            string[] allRoles = base.Roles.Split(',');
            foreach(string role in allRoles)
            {
                if (httpContext.User.IsInRole(role))
                    return true;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "MyAccount",
                        action = "Login"
                    })
                );
        }
    }
}