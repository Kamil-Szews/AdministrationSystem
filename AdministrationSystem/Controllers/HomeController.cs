using AdministrationSystem.Data;
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
            PdfGeneratorService pdfGeneratorService,
            FirebaseConnection firebaseConnection
        )
        {
            _logger = logger;
            this.users = users;
            this.pdfGeneratorService = pdfGeneratorService;
            this.firebaseConnection = firebaseConnection;
        }

        #endregion

        #region Properties
        
        private readonly ILogger<HomeController> _logger;
        private readonly Users users;
        private readonly PdfGeneratorService pdfGeneratorService;
        private readonly FirebaseConnection firebaseConnection;
        #endregion

       public IActionResult Index()
        {
            List<User> x = users.GetAllUsers();
            //var z = pdfGeneratorService.pdfAttendanceList(x, "-NnUwgu_NwPY6F8PrIwg");
            firebaseConnection.Storage();
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