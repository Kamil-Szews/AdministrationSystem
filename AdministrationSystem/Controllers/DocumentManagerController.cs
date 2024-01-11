using AdministrationSystem.Models;
using AdministrationSystem.Services;
using AdministrationSystem.ViewModels.DocumentManagerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class DocumentManagerController : Controller
    {
        public DocumentManagerController
            (
                Courses courses,
                Users users,
                PdfGeneratorService pdfGeneratorService
            )
        {
            this.courses = courses;
            this.users = users;
            this.pdfGeneratorService = pdfGeneratorService;
        }

        private readonly Courses courses;
        private readonly Users users;
        private readonly PdfGeneratorService pdfGeneratorService;

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult CreateAttedanceList(IndexViewModel indexViewModel)
        {
            string CourseIdInput = indexViewModel.CourseIdInput;
            Course course = courses.GetCourse(CourseIdInput);
            List<User> usersToAttendanceList = users.GetAllUsers()
                .Where(user => user.CourseId == CourseIdInput)
                .ToList();
            var memoryStream = pdfGeneratorService.pdfAttendanceList(usersToAttendanceList, CourseIdInput);
            _ = pdfGeneratorService.PushFile(memoryStream, course);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.Headers.Add("Content-Disposition", "attachment; filename=example.pdf");
            memoryStream.WriteTo(Response.Body);

            return RedirectToAction("Index");
        }

    }
}
