using AdministrationSystem.Data;
using AdministrationSystem.Models;

namespace UnitTests.ModelsTests
{
    public class CoursesTests
    {
        [Fact]
        public void AddAndGetCourse_Test()
        {
            // arrange
            var firebaseConnection = new FirebaseConnection();
            var courses = new Courses(firebaseConnection);

            // act
            string courseId = courses.AddCourseToDatabase(new Course
            {
                Name = "TestCourse",
                Location = "ChinaTown",
                Day = "Friday",
                StartingTime = "15:00",
                EndingTime = "16:00",
                Teacher = "Jan Kowalski",
                Description = "Great test course",
                MembersCount = 15
            });
            var course = courses.GetCourse(courseId);
            courses.DeleteCourse(courseId);

            // assert
            Assert.Equal("TestCourse", course.Name);
            Assert.Equal("ChinaTown", course.Location);
            Assert.Equal("Friday", course.Day);
            Assert.Equal("15:00", course.StartingTime);
            Assert.Equal("16:00", course.EndingTime);
            Assert.Equal("Jan Kowalski", course.Teacher);
            Assert.Equal("Great test course", course.Description);
            Assert.Equal(15, course.MembersCount);
            Assert.Equal("15:00 16:00", course.Time);
        }

        // with existing Id
        [Fact]
        public void DeleteCourse1_Test()
        {
            // arrange
            var firebaseConnection = new FirebaseConnection();
            var courses = new Courses(firebaseConnection);
            string courseId = courses.AddCourseToDatabase(new Course
            {
                Name = "TestCourse",
                Location = "ChinaTown",
                Day = "Friday",
                StartingTime = "15:00",
                EndingTime = "16:00",
                Teacher = "Jan Kowalski",
                Description = "Great test course",
                MembersCount = 15
            });

            // act
            courses.DeleteCourse(courseId);
            var course = courses.GetCourse(courseId);

            // assert
            Assert.Null(course.Name);
            Assert.Null(course.Location);
            Assert.Null(course.Day);
            Assert.Null(course.StartingTime);
            Assert.Null(course.EndingTime);
            Assert.Null(course.Teacher);
            Assert.Null(course.Description);
            Assert.Null(course.MembersCount);
            Assert.Null(course.Time);
        }

        // with non-existent Id
        [Fact]
        public void DeleteCourse2_Test()
        {
            // arrange
            var firebaseConnection = new FirebaseConnection();
            var courses = new Courses(firebaseConnection);

            // act
            try
            {
                courses.DeleteCourse("HelloItsMe");
            }

            // assert
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void GetAllCourses_Test()
        {
            // arrange
            var firebaseConnection = new FirebaseConnection();
            var courses = new Courses(firebaseConnection);
            string courseId = courses.AddCourseToDatabase(new Course
            {
                Name = "TestCourse",
                Location = "ChinaTown",
                Day = "Friday",
                StartingTime = "15:00",
                EndingTime = "16:00",
                Teacher = "Jan Kowalski",
                Description = "Great test course",
                MembersCount = 15
            });

            // act
            var ListOfCourses = courses.GetAllCourses();

            // assert
            if (ListOfCourses.Count > 0 ) 
            {
                foreach(var course in ListOfCourses)
                {
                    Course tempCourse = courses.GetCourse(course.Id);
                    if(tempCourse.Id == null || tempCourse.Id == "null")
                    {
                        courses.DeleteCourse(courseId);
                        Assert.Fail("");
                    }
                }
                courses.DeleteCourse(courseId);
            }
            else
            {
                courses.DeleteCourse(courseId);
                Assert.Fail("");
            }
        }

        [Fact]
        public void ModifyCourse_Test()
        {
            // arrange
            var firebaseConnection = new FirebaseConnection();
            var courses = new Courses(firebaseConnection);
            string courseId = courses.AddCourseToDatabase(new Course
            {
                Name = "TestCourse",
                Location = "ChinaTown",
                Day = "Friday",
                StartingTime = "15:00",
                EndingTime = "16:00",
                Teacher = "Jan Kowalski",
                Description = "Great test course",
                MembersCount = 15
            });
            Course newCourse = new Course() 
            {
                Name = "TestCourseNew",
                Location = "ChinaTownNew",
                Day = "FridayNew",
                StartingTime = "15:00New",
                EndingTime = "16:00New",
                Teacher = "Jan KowalskiNew",
                Description = "Great test courseNew",
                MembersCount = 20
            };

            // act
            courses.ModifyCourse(courseId, newCourse);
            var course = courses.GetCourse(courseId);
            courses.DeleteCourse(courseId);

            // assert
            Assert.Equal("TestCourseNew", course.Name);
            Assert.Equal("ChinaTownNew", course.Location);
            Assert.Equal("FridayNew", course.Day);
            Assert.Equal("15:00New", course.StartingTime);
            Assert.Equal("16:00New", course.EndingTime);
            Assert.Equal("Jan KowalskiNew", course.Teacher);
            Assert.Equal("Great test courseNew", course.Description);
            Assert.Equal(20, course.MembersCount);
            Assert.Equal("15:00New 16:00New", course.Time);
        }
    }
}
