using AdministrationSystem.Models;
using AdministrationSystem.ViewModels.UsersManagerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class UsersManagerController : Controller
    {
        #region Constructors

        public UsersManagerController(
            Users users,
            Courses courses
            )
        {
            this.users = users;
            this.courses = courses;
        }

        #endregion

        #region Properties
        
        private Users users;
        private Courses courses;
        
        #endregion

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.AllCourses = courses.GetAll();
            model.AllCoursesNames = model.AllCourses
                .Select(course => course.Name)
                .Distinct()
                .ToList();
            model.AllLocationNames = model.AllCourses
                .Select(course => course.Location)
                .Distinct()
                .ToList();
            model.AllUsers = users.GetAll();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SearchCourse(IndexViewModel model, string courseDropdownName, string courseDropdownLocation)
        {
            model.CourseNameInputText = courseDropdownName;
            model.LocationInputText = courseDropdownLocation;
            model.AllCourses = courses.GetAll();
            model.AllCoursesNames = model.AllCourses
                .Select(course => course.Name)
                .Distinct()
                .ToList();
            model.AllLocationNames = model.AllCourses
                .Select(course => course.Location)
                .Distinct()
                .ToList();
            model.AllUsers = users.GetAll();
            model.InputCourses = model.AllCourses
                .Where(course => course.Name == courseDropdownName && course.Location == courseDropdownLocation)
                .ToList();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult AddUser(IndexViewModel model, string courseDropdownId)
        {
            users.Add(new User(
                model.NameInputText,
                model.SurnameInputText,
                model.EmailInputText,
                model.PhoneInputText,
                courseDropdownId
                ));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ModifyUser(IndexViewModel model, string courseDropdownId, string DropdownUserId)
        {
            User newUser = new User()
            {
                Name = model.NameInputText != null ? model.NameInputText : null,
                Surname = model.SurnameInputText != null ? model.SurnameInputText : null,
                Email = model.EmailInputText != null ? model.EmailInputText : null,
                Phone = model.PhoneInputText != null ? model.PhoneInputText : null,
                CourseId = courseDropdownId
            };
            users.Modify(DropdownUserId, newUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(string courseDropdownUserId)
        {
            users.Delete(courseDropdownUserId);
            return RedirectToAction("Index");
        }
    }
}
