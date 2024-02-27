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
            string description,
            int membersCount
            )
        {
            this.Name = name;   
            this.Location = location;
            this.Day = day;
            this.StartingTime = startingTime;
            this.EndingTime = endingTime;
            this.Teacher = teacher; 
            this.Description = description;
            this.MembersCount = membersCount;
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
            int membersCount,
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
            this.MembersCount = membersCount;
            this.Id = id;
            this.Time = StartingTime + " " + EndingTime;
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
        public string Teacher { get; set; }
        public string Description { get; set; }
        public int? MembersCount { get; set; }
        public string Id { get; set; }
    }
}
