using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers
{
	public class NumbersController : Controller
	{
		private readonly ILogger<NumbersController> logger;

        public NumbersController(ILogger<NumbersController> _logger)
        {
				logger = _logger;
        }
        public IActionResult Index()
		{
			return View(50);
		}
		[HttpGet]
		public IActionResult Limit(int limit)
		{
			return View("Index", limit);
		}
	}
}
