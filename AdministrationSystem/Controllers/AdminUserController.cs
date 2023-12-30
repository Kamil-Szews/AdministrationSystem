using AdministrationSystem.Data;
//using AdministrationSystem.Data.FirebaseConnection;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AdministrationSystem.Controllers
{
    public class AdminUserController : Controller
    {
        AdminUserController
            (
                FirebaseConnection firebaseConnection
            )
        { 
            this.firebaseConnection = firebaseConnection;
        }
        #region Properties
        
        private readonly FirebaseConnection firebaseConnection;
        
        #endregion
        public IActionResult Index()
        {

            /*        string authSecret = "pyfh6tC0C3KKXhqfnu7T2LKmpt4Ptq6OuzDGQnW7";
                    string basePath = "https://tigerbytes-2ffa5-default-rtdb.europe-west1.firebasedatabase.app";
                    IFirebaseConfig config = new FirebaseConfig
                    {
                        AuthSecret = authSecret,
                        BasePath = basePath
                    };
                    IFirebaseClient client = new FireSharp.FirebaseClient(config);
                    if (!string.IsNullOrEmpty(basePath) && !string.IsNullOrEmpty(authSecret) && client != null)
                    {
                        var data = new
                        {
                            Name = "TEST",
                            Phone = "123123123"
                        };
                        var response = client.Push("doc/", data);
                    } */
            var client = firebaseConnection.client();
            if( client != null ) 
            {
                var data = new
                {
                    Name = "Kasztan",
                    Phone = "999999999"
                };
                var response = client.Push("doc/", data);
            }
            return View();
        }
    }
}
