using Microsoft.AspNetCore.Mvc;

namespace iKnow.Web.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
