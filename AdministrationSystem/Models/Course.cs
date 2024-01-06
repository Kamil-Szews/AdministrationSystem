
namespace AdministrationSystem.Models
{
    public class Course
    {
        public Course(){}

        public Course(
            string name,
            string location, 
            string day,
            string startingTime,
            string endingTime,
            string teacher,
            string Description
            )
        {
            this.Name = name;   
            this.Location = location;
            this.Day = day;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
            this.Teacher = teacher; 
            this.Description = Description;
            Id = "";
            this.Time = StartingTime + " " + EndingTime;
        }

        public Course(
            string name,
            string location,
            string day,
            string startingTime,
            string endingTime,
            string teacher,
            string description,
            string id
            )
        {
            this.Name = name;
            this.Location = location;
            this.Day = day;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
            this.Teacher = teacher;
            this.Description = description;
            this.Id = id;
            this.Time = StartingTime + " " + EndingTime;
        }

        public Course(
            string course
            )
        {
            string[] courseParts = course.Split(' ');
            this.Location = courseParts[0];
            this.Day = courseParts[1];
            this.Time = courseParts[2];
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
        public string Teacher { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }


        public string CourseString()
        {
            return Location + " " + Day + " " + Time;
        }
    }
}
