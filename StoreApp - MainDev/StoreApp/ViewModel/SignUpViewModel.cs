using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Services;

namespace StoreApp.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        private string _myProperty = "SignIn/SignUp Page";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand _signInCommand;
        private RelayCommand _signUpCommand;

        public SignUpViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            SignInCommand = new RelayCommand(SignIn);
            SignUpCommand = new RelayCommand(SignUp);
        }

        private void SignUp()
        {
            _navigationService.NavigateTo("ItemSelectionView");
        }

        private void SignIn()
        {
            bool isLoginSuccess = false;
            if(isLoginSuccess)
                _navigationService.NavigateTo("ItemSelectionView");
        }

        public string TitlePageText
        {
            get => _myProperty;
            set => Set(ref _myProperty, value);
        }

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
    }
}
