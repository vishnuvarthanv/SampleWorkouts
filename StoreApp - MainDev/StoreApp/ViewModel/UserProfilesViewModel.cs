using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    public class UserProfilesViewModel : ViewModelBase
    {
        public UserProfilesViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
        }

        #region Properties
        #region Normal Properties
        public string TitlePageText
        {
            get => _myProperty;
            set => Set(ref _myProperty, value);
        }
        #endregion Normal Properties

        #region Command Properties
        public RelayCommand CancelCommand
        {
            get => _cancelCommand;
            set
            {
                Set(ref _cancelCommand, value);
            }
        }

        public RelayCommand DeleteCommand
        {
            get => _deleteCommand;
            set
            {
                Set(ref _deleteCommand, value);
            }
        }

        public RelayCommand EditCommand
        {
            get => _editCommand;
            set
            {
                Set(ref _editCommand, value);
            }
        }

        public RelayCommand AddCommand
        {
            get => _addCommand;
            set
            {
                Set(ref _addCommand, value);
            }
        }
        #endregion Command Properties
        #endregion Properties

        #region Private Variables
        private string _myProperty = "User Profile Page";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _cancelCommand;
        #endregion Private Variables
    }
}
