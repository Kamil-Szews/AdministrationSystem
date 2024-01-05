using System.Reflection;

namespace AdministrationSystem.Models
{
    public class Group
    {
        public Group(){}
        public Group(string group)
        {
            string[] groupParts = group.Split(' ');
            this.Location = groupParts[0];
            this.Day = groupParts[1];
            this.Time = groupParts[2];
        }

        public string Location { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }

        public string GroupString()
        {
            return Location + " " + Day + " " + Time;
        }
    }
}
