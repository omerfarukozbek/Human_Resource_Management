using Microsoft.AspNetCore.Mvc;

namespace HR_T3.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Project Manager"))
                {
                    return RedirectToAction("Index", "ProjectManager");
                }
                if (User.IsInRole("Employee"))
                {
                    return RedirectToAction("Index", "Employee");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}