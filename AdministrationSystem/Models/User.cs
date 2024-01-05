namespace AdministrationSystem.Models
{
    public class User
    {
        #region Constructors

        public User() { }

        public User
        (
            string name,
            string surname,
            string email,
            string phone,
            string location,
            string day,
            string time
        )
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
            Id = "";
            Group = new Group
            {
                Location = location,
                Day = day,
                Time = time
            };
        }

        public User
        (
            string name,
            string surname,
            string email,
            string phone,
            string location,
            string day,
            string time,
            string id
        )
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
            this.Id = id;
            Group = Group = new Group
            {
                Location = location,
                Day = day,
                Time = time
            };
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Models.Group Group { get; set; }
        public string Id { get; set; }

        #endregion
    }
}
