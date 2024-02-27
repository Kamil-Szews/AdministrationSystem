using AdministrationSystem.Data;
using AdministrationSystem.Models;
using AdministrationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsersManager()
        {
            return RedirectToAction("Index", "UsersManager");
        }

        public IActionResult CourseManager()
        {
            return RedirectToAction("Index", "CourseManager");
        }

        public IActionResult EmailManager()
        {
            return RedirectToAction("Index", "EmailManager");
        }

        public IActionResult DocumentManager()
        {
            return RedirectToAction("Index", "DocumentManager");
        }
    }
}