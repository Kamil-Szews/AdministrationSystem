using AdministrationSystem.Models;

namespace AdministrationSystem.ViewModels.DocumentManagerViewModel
{
    public class IndexViewModel
    {
        public string DropCourseId { get; set; }
        public string DropName { get; set; }
        public string DropLocation { get; set; }
        public string NameInput { get; set; }
        public string SurnameInput { get; set; }
        public string EmailInput { get; set; }
        public List<User> ChoosenUsers { get; set; }
        public List<Course> AllCourses { get; set; }
        public List<string> AllCoursesNames { get; set; }
        public List<string> AllLocationNames { get; set; }
    }
}
