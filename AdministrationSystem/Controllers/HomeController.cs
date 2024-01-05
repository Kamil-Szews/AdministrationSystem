using AdministrationSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
            //User user = new User("Emilia", "Szews", "emiliaszews123@gmail.com", "69696969", "Suchy_Las", "Poniedzialek", "15:00");
            //User user1 = new User("Emilia", "Szews", "emiliaszews123@gmail.com", "69696969", "Suchy_Las", "Wtorek", "15:00", "-NmxA4LcdTBCikORM7ju");
            //        users.AddUser(user); 
            //        users.DeleteUser(user1);
            //users.GetAllUsers();
            //var x = users.GetUser("-NnOKgYkm8q7tP_Hia-x");
            return View();
        }

        public IActionResult UsersManager()
        {
            return RedirectToAction("Index", "UsersManager");
        }

        public IActionResult AddNewCourse()
        {
            return RedirectToAction("Index", "UsersManager");
        }

        public IActionResult EmailSender()
        {
            return View();
        }

        public IActionResult GenerateAttendanceList()
        {
            return View();
        }

        public IActionResult Podstrona3()
        {
            return View();
        }
    }
}