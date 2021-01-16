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

        public IActionResult Index()
        {
            var users = userService.GetAllUsers();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, UserViewModel>());
            var userViewModel = new Mapper(config).Map<IList<UserViewModel>>(users);

            return View(userViewModel);
        }
       
        [HttpGet]
        public IActionResult Get(int? roleId)
        {
            if (roleId == null) return RedirectToAction("Index");
            ViewBag.RoleId = roleId;
            return View();
        }
        [HttpPost]
        public string Buy(UserViewModel user)
        {
            return "Thank you, " + user.Login + ", for change!";
        }
    }
}
