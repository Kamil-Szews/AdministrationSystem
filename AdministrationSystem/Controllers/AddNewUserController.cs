using AdministrationSystem.Models;
using AdministrationSystem.ViewModels.AddNewUserViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class AddNewUserController : Controller
    {
        #region Constructors

        public AddNewUserController
        (

        )
        {

        }

        #endregion

        #region Properties

        #endregion
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                FirstLabelText = "Pole 1:",
                SecondLabelText = "Pole 2:",
                ThirdLabelText = "Pole 3:"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(IndexViewModel model)
        {
            // Tutaj możesz obsłużyć przesłane dane z formularza
            // model.FirstInputText, model.SecondInputText, model.ThirdInputText zawierają wartości wpisane w pola tekstowe

            return RedirectToAction("Index");
        }
    }
}
