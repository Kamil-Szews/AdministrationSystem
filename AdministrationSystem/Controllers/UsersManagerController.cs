using AdministrationSystem.Models;
using AdministrationSystem.ViewModels.UsersManagerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AdministrationSystem.Controllers
{
    public class UsersManagerController : Controller
    {
        #region Constructors

        public UsersManagerController(
            Users users
            )
        {
            this.users = users;
        }

        #endregion

        #region Properties
        
        private Users users;
        
        #endregion

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.AllUsers = users.GetAllUsers();
            return View(model);
        }



        [HttpPost]
        public IActionResult AddUser(IndexViewModel model)
        {
            string[] groupParts = model.GroupInputText.Split(' ');
            users.AddUserToDatabase(new User(
                model.NameInputText,
                model.SurnameInputText,
                model.EmailInputText,
                model.PhoneInputText,
                groupParts[0],
                groupParts[1],
                groupParts[2]
                ));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ModifyUser(IndexViewModel model)
        {
            users.AddUserToDatabase(new User(
                model.NameInputText,
                model.SurnameInputText,
                model.EmailInputText,
                model.PhoneInputText,
                model.GroupInputText,
                model.GroupInputText,
                model.GroupInputText
                ));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(IndexViewModel model)
        {
            string[] groupParts = model.GroupInputText.Split(' ');
            users.AddUserToDatabase(new User(
                model.NameInputText,
                model.SurnameInputText,
                model.EmailInputText,
                model.PhoneInputText,
                groupParts[0],
                groupParts[1],
                groupParts[2]
                ));
            return RedirectToAction("Index");
        }
    }
}
