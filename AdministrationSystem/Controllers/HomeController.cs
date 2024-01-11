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
            FirebaseConnection firebaseConnection,
            Courses courses
        )
        {
            _logger = logger;
            this.users = users;
            this.pdfGeneratorService = pdfGeneratorService;
            this.firebaseConnection = firebaseConnection;
            this.courses = courses;
        }

        #endregion

        #region Properties
        
        private readonly ILogger<HomeController> _logger;
        private readonly Users users;
        private readonly Courses courses;
        private readonly PdfGeneratorService pdfGeneratorService;
        private readonly FirebaseConnection firebaseConnection;
        #endregion

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