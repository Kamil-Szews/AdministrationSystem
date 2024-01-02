namespace AdministrationSystem.Models
{
    public class User
    {
        #region Constructors

        public User() { }

        public User
        (
            string Name,
            string Surname,
            string Email,
            string Phone,
            string Location,
            string Day,
            string Time
        )
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Phone = Phone;
            this.Location = Location;
            this.Day = Day;
            this.Time = Time;
            Id = "";
            Group = Location + " " + Day + " " + Time;
        }

        public User
        (
            string Name,
            string Surname,
            string Email,
            string Phone,
            string Location,
            string Day,
            string Time,
            string Id
        )
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Phone = Phone;
            this.Location = Location;
            this.Day = Day;
            this.Time = Time;
            this.Id = Id;
            Group = Location + " " + Day + " " + Time;
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Group { get; set; }
        public string Id { get; set; }

        #endregion
    }
}
