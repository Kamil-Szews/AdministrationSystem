using Firebase.Storage;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Diagnostics;
using System.IO;

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
       
        public async Task Storage()
        {
            try
            {
                var stream = File.Open(@"C:\Users\Dell\Desktop\test.pdf", FileMode.Open);
                FirebaseStorage storage = new FirebaseStorage("tigerbytes-2ffa5.appspot.com", new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(config().AuthSecret)
                });
                var task = storage.Child("AttendanceLists/test.pdf").PutAsync(stream);
                var urlD = await task;
                Debug.WriteLine(urlD);
            }
            catch (Exception ex) { }
        }
    }
}
