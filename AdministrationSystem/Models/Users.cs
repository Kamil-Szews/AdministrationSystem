using AdministrationSystem.Data;
using Firebase.Auth.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace AdministrationSystem.Models
{
    public class Users
    {
        #region Constructors

        public Users
        (
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

        public List<User> GetAllUsers()
        {
            var client = firebaseConnection.client();
            var json = client.Get("Users/");
            JObject obj = JObject.Parse(json.Body);
            List<User> allUsers = new List<User>();
            
            foreach(var nextUser in obj)
            {
                string Id = nextUser.Key;
                User user = GetUser(Id);
                allUsers.Add(user);
            }

            return allUsers;
        }

        public User GetUser(string Id)
        {
            var client = firebaseConnection.client();
            var json = client.Get($"Users/{Id}");
            JObject obj = JObject.Parse(json.Body);
            string name = (string)obj["Name"];
            string surname = (string)obj["Surname"];
            string email = (string)obj["Email"];
            string phone = (string)obj["Phone"];
            string group = (string)obj["Group"];
            User user = new User(name, surname, email, phone, group.Substring(0,group.IndexOf(' ')),
                group.Substring(group.IndexOf(' ', group.IndexOf(' ') + 1) + 1), Id);
                
            return user;
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
                    Group = user.Group,
                    Id = UserId
                };
                client.Set($"Users/{UserId}", newUser);
                user.Id = UserId;
            }
        }

        public void DeleteUserFromDatabase(User user)
        {
            var client = firebaseConnection.client();
            if (client != null)
            {
                client.Delete($"Users/{user.Id}");
            }
        }

        #endregion
    }
}
