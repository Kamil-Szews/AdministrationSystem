using AdministrationSystem.Models;
using AdministrationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors
        
        public HomeController
        (
            ILogger<HomeController> logger,
            Users users,
            PdfGeneratorService pdfGeneratorService
        )
        {
            _logger = logger;
            this.users = users;
            this.pdfGeneratorService = pdfGeneratorService;
        }

        #endregion

        #region Properties
        
        private readonly ILogger<HomeController> _logger;
        private readonly Users users;
        private readonly PdfGeneratorService pdfGeneratorService;

        #endregion

        public IActionResult Index()
        {
            //User user = new User("Emilia", "Szews", "emiliaszews123@gmail.com", "69696969", "Suchy_Las", "Poniedzialek", "15:00");
            //User user1 = new User("Emilia", "Szews", "emiliaszews123@gmail.com", "69696969", "Suchy_Las", "Wtorek", "15:00", "-NmxA4LcdTBCikORM7ju");
            //        users.AddUser(user); 
            //        users.DeleteUser(user1);
            //users.GetAllUsers();
            //var x = users.GetUser("-NnOKgYkm8q7tP_Hia-x");
            List<User> x = users.GetAllUsers();
            pdfGeneratorService.pdfAttendanceList(x, "-NnUwgu_NwPY6F8PrIwg");
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
            return View();
        }

        public IActionResult DocumentManager()
        {
            return View();
        }
    }
}