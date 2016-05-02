using Electron.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronRepository;
using Electron.CustomAttributes;
using System.Web.Script.Serialization;
using System.Web.Security;
using Services.Helpers;
using Electron.ViewModels;
using AutoMapper;

namespace Electron.Controllers
{
    public class MyAccountController : Controller
    {
        private IUserService userService;

        public MyAccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userService.GetByUsername(model.UserName);
                string pass = EncryptPassword.Encrypt(model.Password);
                if (user != null && pass.Equals(user.pass))
                {
                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.Username = user.username;
                    serializeModel.Role = user.UserRoles.First().Role.name;
                    serializeModel.Firstname = user.firstname;
                    serializeModel.Lastname = user.lastname;

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string userData = serializer.Serialize(serializeModel);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        user.username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(15),
                        false,
                        userData
                        );

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    return RedirectToAction("Index", "User", null);
                }
            }

            ModelState.AddModelError("CustomError", "The user name or password provided is incorrect.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            var users = this.userService.GetAllUser().ToList();
            List<string> usernames = new List<string>();
            foreach (var u in users)
            {
                usernames.Add(u.username);
            }
            if (usernames.Contains(model.username))
            {
                ModelState.AddModelError("UserFound", "User name already exists");
                return View(model);
            }

            Mapper.CreateMap<UserViewModel, User>();
            var user = Mapper.Map<UserViewModel, User>(model);
            UserRole role = new UserRole();
            role.role_id = 2;
            role.user_id = model.id;
            user.UserRoles = new List<UserRole>();
            user.UserRoles.Add(role);
            user.pass = EncryptPassword.Encrypt(user.pass);
            this.userService.InsertUser(user);
            return RedirectToAction("Login", "MyAccount");
        }

        public ActionResult Update(string username)
        {
            var user = this.userService.GetByUsername(User.Identity.Name);
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserRole, UserRoleModel>();
            var model = Mapper.Map<User, UserViewModel>(user);
            model.pass = "";
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<UserViewModel, User>();
                Mapper.CreateMap<UserRoleModel, UserRole>();
                var user = Mapper.Map<UserViewModel, User>(model);
                user.pass = EncryptPassword.Encrypt(user.pass);
                this.userService.UpdateUser(user);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }        
    }
}
