using AdministrationSystem.Models;

namespace AdministrationSystem.ViewModels.UsersManagerViewModel
{
    public class IndexViewModel
    {
        public string NameInputText { get; set; }
        public string SurnameInputText { get; set; }
        public string EmailInputText { get; set; }
        public string PhoneInputText { get; set; }
        public string LocationInputText { get; set; }
        public string CourseNameInputText { get; set; }
        public string IdInputText { get; set; }
        public List<User> AllUsers { get; set; }
        public List<Course> AllCourses { get; set; }
        public List<string> AllCoursesNames { get; set; }
        public List<string> AllLocationNames { get; set; }
        public List<Course> InputCourses { get; set; }
    }
}
