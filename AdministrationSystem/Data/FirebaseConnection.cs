using FireSharp.Config;
using FireSharp.Interfaces;

namespace AdministrationSystem.Data
{
    public class FirebaseConnection
    {
        private IFirebaseConfig? config()
        {
            string authSecret = "1rNPiorl7UmteenAYmKMlUzh3z5TB08RDRE8JmHB";
            string basePath = "https://courses-shop-web-application-default-rtdb.europe-west1.firebasedatabase.app";
            
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
