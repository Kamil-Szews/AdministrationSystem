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
            string Time
        )
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Phone = Phone;
            this.Location = Location;
            this.Time = Time;
            Id = "";
            Group = Location + " " + Time;
        }

        public User
       (
           string Name,
           string Surname,
           string Email,
           string Phone,
           string Location,
           string Time,
           string Id
       )
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Phone = Phone;
            this.Location = Location;
            this.Time = Time;
            this.Id = Id;
            Group = Location + " " + Time;
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Group { get; set; }
        public string Id { get; set; }

        #endregion
    }
}
