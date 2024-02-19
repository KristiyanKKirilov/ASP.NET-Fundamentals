using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("/intro")]
    public class IntroController : Controller
    {
        private readonly IStudentService studentService;

        public IntroController(IStudentService _studentService)
        {
            studentService = _studentService;
        }
        public IActionResult Index()
        {
			ViewData["Title"] = "Intro";

			return View();
        }

        public IActionResult GetNumber(int number)
        {
            ViewBag.Title = "GetNumber";    
            return View(number);
        }
        [Route("data")]
        public IActionResult GetStudentData(int id)
        {
            ViewBag.Title = "GetStudentData";

            var model = studentService.GetStudent(id);

            return View("StudentData", model);
        }
        [Route("edit")]
        [HttpPost]
        public IActionResult EditStudent(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View("StudentData", model);
            }

            if (studentService.UpdateStudent(model))
            {
				return RedirectToAction(nameof(GetStudentData), new { id = model.Id})   ;
			}

            return RedirectToAction(nameof(Index));
		}
    }
}
