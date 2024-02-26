using AdministrationSystem.Interfaces;
using AdministrationSystem.Models;
using AdministrationSystem.ViewModels.EmailManagerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class EmailManagerController : Controller
    {
        public EmailManagerController(
             Courses courses,
             Users users,
             IEmailSender emailSender
            ) 
        {
            this.courses = courses;
            this.users = users;
            this.emailSender = emailSender;
        }

        private readonly Courses courses;
        private readonly Users users;
        private readonly IEmailSender emailSender;

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.AllCourses = courses.GetAll(); 
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SearchCourse(IndexViewModel model, List<string> selectedCourses)
        {
            model.AllCourses = courses.GetAll();

            foreach(var courseId in selectedCourses)
            {
                model.SelectedCourses.Add(courses.Get(courseId));
            }

            model.AllUsers = users.GetAll()
                .Where(user => model.SelectedCourses
                .Any(course => course.Id == user.CourseId))
                .Distinct()
                .ToList();

            return View("Index", model);
        }

        public async Task<IActionResult> SendEmail(IndexViewModel model, List<string> selectedUsers, string subjectText, string messageText)
        {
            model.AllCourses = courses.GetAll();

            foreach(var userId in selectedUsers)
            {
                var user = users.Get(userId);
                await emailSender.SendEmailAsync(user.Email, subjectText, messageText);
            }

            return View("Index", model);
        }
    }
}
