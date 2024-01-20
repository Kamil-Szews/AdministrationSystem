using AdministrationSystem.Models;

namespace AdministrationSystem.ViewModels.EmailManagerViewModel
{
    public class IndexViewModel
    {
        public List<User> AllUsers { get; set; }
        public List<Course> AllCourses { get; set; }
        public List<Course> SelectedCourses { get; set; }
    }
}
