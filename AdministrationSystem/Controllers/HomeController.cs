using AdministrationSystem.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdministrationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Users users;
        public HomeController
        (
            ILogger<HomeController> logger,
            Users users
        )
        {
            _logger = logger;
            this.users = users;
        }

        public IActionResult Index()
        {
            users.AddUser("Kamil", "Szews", "kamilszews123@gmail.com", "606808017", "Suchy Las", "15:00");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}