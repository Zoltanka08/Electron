using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;
using Services.Services;
using AutoMapper;
using Electron.Models;
using Electron.ViewModels;
using ElectronRepository.Interfaces;
using ElectronRepository;
using Electron.CustomAttributes;

namespace Electron.Controllers
{
    [UserAuthorize(Roles="admin")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Index(int? id)
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => 
                { 
                    cfg.CreateMap<User, UserViewModel>(); 
                    cfg.CreateMap<UserRole, UserRoleModel>(); 
                }
            );
            IMapper mapper = config.CreateMapper();

            var users = this._userService.GetAllUser();
            var usersModel = mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
            return View(usersModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserViewModel, User>();
                    cfg.CreateMap<UserRoleModel, UserRole>();
                }
                );
                IMapper mapper = config.CreateMapper();

                UserRoleModel role = new UserRoleModel();
                role.role_id = 2;
                role.user_id = model.id;
                model.UserRoles = new List<UserRoleModel>();
                model.UserRoles.Add(role);
                var newUser = mapper.Map<UserViewModel, User>(model);
                this._userService.InsertUser(newUser);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<UserRole, UserRoleModel>();
                }
            );
            IMapper mapper = config.CreateMapper();

            var user = this._userService.GetUserById(id);
            var userViewModel = mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserViewModel, User>();
                    cfg.CreateMap<UserRoleModel, UserRole>();
                }
                );
                IMapper mapper = config.CreateMapper();

                var modifiedUser = mapper.Map<UserViewModel, User>(model);
                this._userService.UpdateUser(modifiedUser);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<UserRole, UserRoleModel>();
                }
            );
            IMapper mapper = config.CreateMapper();

            var user = this._userService.GetUserById(id);
            var userViewModel = mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Delete(UserViewModel model)
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserViewModel, User>();
                    cfg.CreateMap<UserRoleModel, UserRole>();
                }
                );
            IMapper mapper = config.CreateMapper();

            var deletedUser = mapper.Map<UserViewModel, User>(model);
            this._userService.DeleteUser(deletedUser);

            return RedirectToAction("Index");
        }
    }
}
