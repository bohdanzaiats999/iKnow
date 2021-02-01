using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKnow.Web.Controllers
{
    public class AdminPanel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
