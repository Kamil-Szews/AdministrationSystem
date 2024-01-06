using AdministrationSystem.Data;
using Newtonsoft.Json.Linq;

namespace AdministrationSystem.Models
{
    public class Users
    {
        #region Constructors

        public Users(
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

        public User GetUser(string Id)
        {
            var client = firebaseConnection.client();
            var json = client.Get($"Users/{Id}");
            JObject obj = JObject.Parse(json.Body);
            string name = (string)obj["Name"];
            string surname = (string)obj["Surname"];
            string email = (string)obj["Email"];
            string phone = (string)obj["Phone"];
            string courseId = (string)obj["Course"];
            User user = new User(name, surname, email, phone, courseId, Id);
            return user;
        }

        public List<User> GetAllUsers()
        {
            var client = firebaseConnection.client();
            var json = client.Get("Users/");
            if (json.Body != "null")
            {
                JObject obj = JObject.Parse(json.Body);
                List<User> allUsers = new List<User>();

                foreach (var nextUser in obj)
                {
                    string Id = nextUser.Key;
                    User user = GetUser(Id);
                    allUsers.Add(user);
                }

                return allUsers;
            }
            return new List<User>();
        }

        public void AddUserToDatabase(User user)
        {
            var client = firebaseConnection.client();
            if (client != null)
            {
                var JsonUserId = client.Push("Users/", "");
                string UserId = (string)JObject.Parse(JsonUserId.Body)["name"];
                var newUser = new
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Phone = user.Phone,
                    Course = user.CourseId,
                    Id = UserId
                };
                client.Set($"Users/{UserId}", newUser);
                user.Id = UserId;
            }
        }

        public void DeleteUserFromDatabase(string userId)
        {
            var client = firebaseConnection.client();
            if (client != null)
            {
                client.Delete($"Users/{userId}");
            }
        }

        public void ModifyUser(string userId, User newUser)
        {
            var client = firebaseConnection.client();
            User oldUser = GetUser(userId);
            newUser.Name = newUser.Name == null ? oldUser.Name : newUser.Name;
            newUser.Surname = newUser.Surname == null ? oldUser.Surname : newUser.Surname;
            newUser.Email = newUser.Email == null ? oldUser.Email : newUser.Email;
            newUser.Phone = newUser.Phone == null ? oldUser.Phone : newUser.Phone;
            newUser.CourseId = newUser.CourseId == null ? oldUser.CourseId : newUser.CourseId;
            client.Set($"Users/{userId}", newUser);
        }


        #endregion
    }
}
