using AdministrationSystem.Models;

namespace AdministrationSystem.ViewModels.CourseManagerViewModel
{
    public class IndexViewModel
    {
        public string NameInput { get; set; }
        public string LocationInput { get; set; }
        public string DayInput { get; set; }
        public string StartingTimeInput { get; set; }
        public string EndingTimeInput { get; set; }
        public string TeacherInput { get; set; }
        public string DescriptionInput { get; set; }
        public int MembersCountInput { get; set; }
        public List<Course> AllCourses { get; set; }
        public List<string> AllCoursesNames { get; set; }
        public List<string> AllLocationNames { get; set; }
    }
}
