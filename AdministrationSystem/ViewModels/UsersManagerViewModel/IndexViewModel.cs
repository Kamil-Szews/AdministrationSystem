using AdministrationSystem.Models;

namespace AdministrationSystem.ViewModels.UsersManagerViewModel
{
    public class IndexViewModel
    {
        public string NameInputText { get; set; }
        public string SurnameInputText { get; set; }
        public string EmailInputText { get; set; }
        public string PhoneInputText { get; set; }
        public string GroupInputText { get; set; }
        public string IdInputText { get; set; }
        public List<User> AllUsers { get; set; }
    }
}
