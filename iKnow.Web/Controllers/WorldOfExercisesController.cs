using iKnow.BLL.Interfaces;
using iKnow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace iKnow.Web.Controllers
{
    public class WorldOfExercisesController : Controller
    {
        IExcerciseService excerciseService;
        public WorldOfExercisesController(IExcerciseService excerciseService)
        {
            this.excerciseService = excerciseService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            int[] arr = new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 };
            var excerciseViewModel = new ExcerciseViewModel
            {
                Number = excerciseService.Excercise1_FindOdd(arr),
                Text = excerciseService.Excercise2_RepeatString(5,"*")
            };
            return View(excerciseViewModel);
        }
        public IActionResult AddArray(ExcerciseViewModel viewModel)
        {
            return View("Index");
        }
    }
}
