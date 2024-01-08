using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class EmailManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
