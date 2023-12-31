using AdministrationSystem.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdministrationSystem.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors
        
        public HomeController
        (
            ILogger<HomeController> logger,
            Users users
        )
        {
            _logger = logger;
            this.users = users;
        }

        #endregion

        #region Properties
        
        private readonly ILogger<HomeController> _logger;
        private readonly Users users;

        #endregion

        public IActionResult Index()
        {
            User user = new User("Emilia", "Szews", "emiliaszews123@gmail.com", "69696969", "Suchy_Las", "15:00");
            User user1 = new User("Emilia", "Szews", "emiliaszews123@gmail.com", "69696969", "Suchy_Las", "15:00", "-NmxA4LcdTBCikORM7ju");
            //        users.AddUser(user); 
            //        users.DeleteUser(user1);
            users.GetAllUsers();
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