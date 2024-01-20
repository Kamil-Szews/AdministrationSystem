using AdministrationSystem.Data;
using Newtonsoft.Json.Linq;

namespace AdministrationSystem.Models
{
    public class Admin
    {
        public Admin(
            FirebaseConnection firebaseConnection
            )
        {
            this.firebaseConnection = firebaseConnection;
        }

        public Admin(   
            string Email,
            string Password
            )
        {
            this.Email = Email;
            this.Password = Password;
        }

        private readonly FirebaseConnection firebaseConnection;


        public string Email { get; set; }
        public string Password { get; set; }

        public Admin GetAdmin()
        {
            var client = firebaseConnection.client();
            var json = client.Get($"Admin");

            if (json.Body != null && json.Body != "null")
            {
                JObject obj = JObject.Parse(json.Body);
                string email = (string)obj["Email"];
                string password = (string)obj["Password"];

                Admin admin = new Admin(email, password);
                return admin;
            }
            return new Admin("", "");
        }
    }
}
