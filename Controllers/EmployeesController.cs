using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApi.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
