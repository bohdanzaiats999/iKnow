using AutoMapper;
using iKnow.BLL.Interfaces;
using iKnow.BLL.Models;
using iKnow.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iKnow.Web.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = userService.GetAllUsers();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, UserViewModel>());
            var userViewModel = new Mapper(config).Map<IList<UserViewModel>>(users);

            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<LoginViewModel, UserModel>());
            var loginModel = new Mapper(config).Map<UserModel>(viewModel);

            userService.Login(loginModel);

            return userService.GetRoleId() == 1 ? RedirectToAction("Index", "AdminPanel") : RedirectToAction("Index", "UserPanel");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel viewModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<RegistrationViewModel, UserModel>());
            var registrationModel = new Mapper(config).Map<UserModel>(viewModel);

            //Assign to new user status "User"
            registrationModel.RoleId = (int)UserRoles.User;

            userService.Registration(registrationModel);

            return Content("Successful");
        }
    }
}
