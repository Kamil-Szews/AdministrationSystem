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
            string courseId
        )
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
            this.CourseId = courseId;
            Id = "";

        }

        public User
        (
            string name,
            string surname,
            string email,
            string phone,
            string courseId,
            string id
        )
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
            this.CourseId = courseId;
            this.Id = id;
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Id { get; set; }
        public string CourseId { get; set; }

        #endregion
    }
}
