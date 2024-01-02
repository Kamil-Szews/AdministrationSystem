using AdministrationSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class SendEmailController : Controller
    {
        #region Constructors

        public SendEmailController
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

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
