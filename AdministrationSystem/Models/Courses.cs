using AdministrationSystem.Data;
using Firebase.Auth;
using Newtonsoft.Json.Linq;

namespace AdministrationSystem.Models
{
    public class Courses
    {
        #region Constructors

        public Courses(
            FirebaseConnection firebaseConnection
            )
        {
            this.firebaseConnection = firebaseConnection;
        }

        #endregion

        #region Properties

        FirebaseConnection firebaseConnection;

        #endregion

        #region Methods
        public List<Course> GetAllCourses()
        {
            var client = firebaseConnection.client();
            var json = client.Get("Courses/");
            JObject obj = JObject.Parse(json.Body);
            List<Course> allCourses = new List<Course>();

            foreach (var nextUser in obj)
            {
                string Id = nextUser.Key;
                Course course = GetCourse(Id);
                allCourses.Add(course);
            }

            return allCourses;
        }

        public Course GetCourse(string Id)
        {
            var client = firebaseConnection.client();
            var json = client.Get($"Courses/{Id}");
            JObject obj = JObject.Parse(json.Body);
            string name = (string)obj["Name"];
            string location = (string)obj["Location"];
            string day = (string)obj["Day"];
            string startingTime = (string)obj["StartingTime"];
            string endingTime = (string)obj["EndingTime"];
            string teacher = (string)obj["Teacher"];
            string description = (string)obj["Description"];
            Course course = new Course(name, location, day, startingTime, endingTime, teacher, description, Id);
            return course;
        }

        public void AddCourseToDatabase(Course course)
        {
            var client = firebaseConnection.client();
            var JsonCourseId = client.Push("Courses/", "");
            string courseId = (string)JObject.Parse(JsonCourseId.Body)["name"];
            var newCourse = new
            {
                Name = course.Name,
                Location = course.Location,
                Day = course.Day,
                StartingTime = course.StartingTime,
                EndingTime = course.EndingTime,
                Teacher = course.Teacher,
                Description = course.Description,
                Id = courseId
            };
            client.Set($"Courses/{courseId}", newCourse);
        }

        public void ModifyCourse(string courseId, Course newCourse)
        {
            var client = firebaseConnection.client();
            Course oldCourse = GetCourse(courseId);
            newCourse.Name = newCourse.Name == null ? oldCourse.Name : newCourse.Name;
            newCourse.Location = newCourse.Location == null ? oldCourse.Location : newCourse.Location;
            newCourse.Day = newCourse.Day == null ? oldCourse.Day : newCourse.Day;
            newCourse.StartingTime = newCourse.StartingTime == null ? oldCourse.StartingTime : newCourse.StartingTime;
            newCourse.EndingTime = newCourse.EndingTime == null ? oldCourse.EndingTime : newCourse.EndingTime;
            newCourse.Teacher = newCourse.Teacher == null ? oldCourse.Teacher : newCourse.Teacher;
            newCourse.Description = newCourse.Description == null ? oldCourse.Description : newCourse.Description;
            client.Set($"Courses/{courseId}", newCourse);
        }
        public void DeleteCourse(string courseId)
        {
            var client = firebaseConnection.client();
            client.Delete($"Courses/{courseId}");
        }

        #endregion
    }
}
