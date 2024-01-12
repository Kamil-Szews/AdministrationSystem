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
            model.AllCourses = courses.GetAllCourses();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SearchCourse(IndexViewModel model, string courseDropdownId)
        {
            model.AllCourses = courses.GetAllCourses();
            model.DropCourseId = courseDropdownId;
            model.ChoosenUsers = users.GetAllUsers()
                .Where(user => user.CourseId == courseDropdownId)
                .ToList();
            TempData["courseDropdownId"] = courseDropdownId;
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateAttedanceList(IndexViewModel model, List<string> selectedUsers)
        {
            string courseDropdownId = TempData["courseDropdownId"] as string;
            Course course = courses.GetCourse(courseDropdownId);
            List<User> usersToAttendanceList = new List<User>();

            foreach(string userId in selectedUsers)
            {
                usersToAttendanceList.Add(users.GetUser(userId));
            }
            var memoryStream = pdfGeneratorService.pdfAttendanceList(usersToAttendanceList, courseDropdownId);
            _ = pdfGeneratorService.PushFile(memoryStream, course);
            return RedirectToAction("Index");
        }
    }
}
