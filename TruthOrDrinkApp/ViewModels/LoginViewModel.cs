using Core.Interfaces;
using System.Windows.Input;


namespace TruthOrDrinkApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        private string _email;
        private string _password;
        private string _errorMessage;
        private bool _hasError;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            Title = "Truth or Drink – Login";

            LoginCommand = new Command(async () => await OnLoginAsync(), CanExecuteLogin);
        }

        public string Email
        {
            get => _email;
            set
            {
                if (SetProperty(ref _email, value))
                {
                    ((Command)LoginCommand).ChangeCanExecute();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (SetProperty(ref _password, value))
                {
                    ((Command)LoginCommand).ChangeCanExecute();
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (SetProperty(ref _errorMessage, value))
                {
                    HasError = !string.IsNullOrEmpty(value);
                }
            }
        }

        public bool HasError
        {
            get => _hasError;
            set => SetProperty(ref _hasError, value);
        }

        public ICommand LoginCommand { get; }

        private bool CanExecuteLogin()
        {
            return !IsBusy
                   && !string.IsNullOrWhiteSpace(Email)
                   && !string.IsNullOrWhiteSpace(Password);
        }

        private async Task OnLoginAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            ErrorMessage = string.Empty;

            try
            {
                var success = await _authService.LoginAsync(Email, Password);

                if (success)
                {
                    // TODO: navigate to home after login
                    Email = string.Empty;
                    Password = string.Empty;
                    ErrorMessage = string.Empty; // zet HasError ook op false
                }
                else
                {
                    ErrorMessage = "Ongeldige inloggegevens.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Er ging iets mis bij het inloggen.";
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }
    }
}
