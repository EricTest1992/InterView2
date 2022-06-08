using Microsoft.AspNetCore.Mvc;

namespace InterView.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
