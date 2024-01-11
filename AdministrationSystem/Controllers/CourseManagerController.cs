using Microsoft.AspNetCore.Mvc;
using AdministrationSystem.ViewModels.CourseManagerViewModel;
using AdministrationSystem.Models;

namespace AdministrationSystem.Controllers
{
    public class CourseManagerController : Controller
    {
        public CourseManagerController
            (
                Courses courses
            ) 
        {
            this.courses = courses;
        }

        #region Properties

        public Courses courses;

        #endregion

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.AllCourses = courses.GetAllCourses();
            model.AllCoursesNames = model.AllCourses
                .Select(course => course.Name)
                .Distinct()
                .ToList();
            model.AllLocationNames = model.AllCourses
                .Select(course => course.Location)
                .Distinct()
                .ToList();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult AddCourse(IndexViewModel model)
        {
            courses.AddCourseToDatabase(new Course(
                model.NameInput,
                model.LocationInput,
                model.DayInput,
                model.StartingTimeInput,
                model.EndingTimeInput,
                model.TeacherInput,
                model.DescriptionInput,
                model.MembersCountInput
                ));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SearchCourse(IndexViewModel model, string courseDropdownName, string courseDropdownLocation)
        {
            model.NameInput = courseDropdownName;
            model.LocationInput = courseDropdownLocation;
            model.AllCourses = courses.GetAllCourses();
            model.AllCoursesNames = model.AllCourses
                .Select(course => course.Name)
                .Distinct()
                .ToList();
            model.AllLocationNames = model.AllCourses
                .Select(course => course.Location)
                .Distinct()
                .ToList();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult ModifyCourse(IndexViewModel model, string courseDropdownId)
        {
            Course modifiedCourse = new Course() 
            {
                Name = model.NameInput != null ? model.NameInput : null,
                Location = model.LocationInput != null ? model.LocationInput : null,
                Day = model.DayInput != null ? model.DayInput : null,
                StartingTime = model.StartingTimeInput != null ? model.StartingTimeInput : null,
                EndingTime = model.EndingTimeInput != null ? model.EndingTimeInput : null,
                Teacher = model.TeacherInput != null ? model.TeacherInput : null,
                Description = model.DescriptionInput != null ? model.DescriptionInput : null,
                MembersCount = model.MembersCountInput != null ? model.MembersCountInput : null
            };
            courses.ModifyCourse(courseDropdownId, modifiedCourse);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCourse(string courseDropdownId)
        {
            courses.DeleteCourse(courseDropdownId);
            return RedirectToAction("Index");
        }
    }
}
