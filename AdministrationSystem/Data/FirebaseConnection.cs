using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Owin.Security.Provider;

namespace AdministrationSystem.Data
{
    public class FirebaseConnection
    {
        private IFirebaseConfig? config()
        {
            string authSecret = "pyfh6tC0C3KKXhqfnu7T2LKmpt4Ptq6OuzDGQnW7";
            string basePath = "https://tigerbytes-2ffa5-default-rtdb.europe-west1.firebasedatabase.app";
            
            try
            {
                if (string.IsNullOrEmpty(basePath))
                {
                    throw new Exception("basePath is empty");
                }
                if (string.IsNullOrEmpty(authSecret))
                {
                    throw new Exception("authSecret is empty");
                }
            }
            catch(Exception ex) { return null; }

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };
            return config;
        }

        public IFirebaseClient? client()
        {   
            if(config() == null)
            {
                return null;
            }
            IFirebaseClient client = new FireSharp.FirebaseClient(config());
            return client;
        }
       
    }
}
