using InterView.Models.DAO;
using InterView.Models.ViewModels;
using InterView.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InterView.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
            => _employeeService = employeeService;

        public IActionResult Index()
        {
            List<EmployeeViewModel> vm = _employeeService.GetEmployees();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(EmployeeViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                Employee employee = new()
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Address = vm.Address,
                    Phone = vm.Phone
                };

                _employeeService.InsertEmployees(employee);

                TempData["ResultMsg"] = "新增成功";
            }
            catch (Exception)
            {
                TempData["ResultMsg"] = "新增失敗";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
