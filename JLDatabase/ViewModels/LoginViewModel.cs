using JLDatabase.Validation;

namespace JLDatabase.ViewModels
{
    internal class LoginViewModel
    {
        LoginValidation _validation;
        public LoginViewModel(LoginValidation validation)
        {
            _validation = validation;
        }
    }
}
