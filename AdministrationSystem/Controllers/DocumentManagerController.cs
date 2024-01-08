using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class DocumentManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
