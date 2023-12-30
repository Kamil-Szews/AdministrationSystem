using AdministrationSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace AdministrationSystem.Models
{
    public class Users
    {
        public Users
        (
            FirebaseConnection firebaseConnection
        )
        {
            this.firebaseConnection = firebaseConnection;
        }

        FirebaseConnection firebaseConnection;
        public List<int> GetUsers()
        {
            return new List<int>{2, 3};
        }
        
        public void AddUser(string name, string surname, string email, string phone, string location, string time)
        {
            var client = firebaseConnection.client();
            if (client != null)
            {
                var newUser = new
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = phone,
                    Group = location + time

                };
                var response = client.Push("Users/", newUser);
            }
        }
    }
}
