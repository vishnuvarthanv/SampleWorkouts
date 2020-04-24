using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Services;

namespace StoreApp.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        #region Constructor
        public SignUpViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            SignInCommand = new RelayCommand(SignIn);
            SignUpCommand = new RelayCommand(SignUp);
            LoginCommand = new RelayCommand(Login);
        }
        #endregion Constructor

        #region Private Methods
        private void Login()
        {
            bool isLoginSuccess = true;
            if (isLoginSuccess & UserId=="admin")
            {
                //_navigationService.NavigateTo("UserProfiles");
                _navigationService.NavigateTo("MasterPages");
            }
            else
            {
                _navigationService.NavigateTo("ItemSelectionView");
            }
        }

        private void SignUp()
        {
            IsSignUp = Visibility.Visible; ;
            IsSignIn = Visibility.Collapsed;
            IsDefaultPage = Visibility.Collapsed;
        }

        private void SignIn()
        {

            IsSignIn = Visibility.Visible;
            IsSignUp = Visibility.Collapsed;
            IsDefaultPage = Visibility.Collapsed;
        }
        #endregion Private Methods

        #region Properties
        #region Normal Properties
        public string TitlePageText
        {
            get => _myProperty;
            set => Set(ref _myProperty, value);
        }

        public string UserId
        {
            get => _userId;
            set => Set(ref _userId, value);
        }

        public Visibility IsSignIn
        {
            get => _isSignIn;
            set => Set(ref _isSignIn, value);
        }

        public Visibility IsSignUp
        {
            get => _isSignUp;
            set => Set(ref _isSignUp, value);
        }

        public Visibility IsDefaultPage
        {
            get => _isDefaultPage;
            set => Set(ref _isDefaultPage, value);
        }
        #endregion Normal Properties

        #region Command Properties
        public RelayCommand SignInCommand
        {
            get => _signInCommand;
            set
            {
                Set(ref _signInCommand, value);
            }
        }

        public RelayCommand SignUpCommand
        {
            get => _signUpCommand;
            set
            {
                Set(ref _signUpCommand, value);
            }
        }

        public RelayCommand LoginCommand
        {
            get => _LoginCommand;
            set
            {
                Set(ref _LoginCommand, value);
            }
        }
        #endregion Command Properties
        #endregion Properties

        #region Private Variables
        private string _myProperty = "SignIn/SignUp Page";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand _signInCommand;
        private RelayCommand _signUpCommand;
        private RelayCommand _LoginCommand;
        private Visibility _isSignIn = Visibility.Collapsed;
        private Visibility _isSignUp = Visibility.Collapsed;
        private Visibility _isDefaultPage = Visibility.Visible;
        private string _userId = string.Empty;
        #endregion Private Variables
    }
}
