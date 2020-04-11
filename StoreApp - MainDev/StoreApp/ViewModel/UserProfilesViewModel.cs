using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Model;
using StoreApp.Model.Interfaces;
using StoreApp.RepositoryLayer;
using StoreApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    public class UserProfilesViewModel : ViewModelBase
    {
        #region Constructor
        public UserProfilesViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            LoadCommand = new RelayCommand(OnLoad);
            EditCommand = new RelayCommand<IUserProfile>(Modify, SelectedUserProfile != null);
            AddCommand = new RelayCommand<IUserProfile>(Add, SelectedUserProfile != null);
            DeleteCommand = new RelayCommand<IUserProfile>(Delete, SelectedUserProfile != null);
            CancelCommand = new RelayCommand(Cancel);
        }
        #endregion Constructor

        #region Properties
        #region Normal Properties
        public string TitlePageText
        {
            get => _myProperty;
            set => Set(ref _myProperty, value);
        }

        public ObservableCollection<IUserProfile> UserProfiles
        {
            get => _userProfile;
            set => Set(ref _userProfile, value);
        }
        public IUserProfile SelectedUserProfile
        {
            get => _selectedUserProfile;
            set
            {
                Set(ref _selectedUserProfile, value);//value == null ? new UserProfile() : value
                //IsButtonEnable = !(_selectedUserProfile == null);
            }
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

        public RelayCommand<IUserProfile> DeleteCommand
        {
            get => _deleteCommand;
            set
            {
                Set(ref _deleteCommand, value);
            }
        }

        public RelayCommand<IUserProfile> EditCommand
        {
            get => _editCommand;
            set => Set(ref _editCommand, value); 
        }

        public RelayCommand<IUserProfile> AddCommand
        {
            get => _addCommand;
            set
            {
                Set(ref _addCommand, value);
            }
        }

        public RelayCommand LoadCommand
        {
            get => _loadCommand;
            set
            {
                Set(ref _loadCommand, value);
            }
        }
        #endregion Command Properties
        #endregion Properties

        #region Methods
        private void OnLoad()
        {
            UserProfiles.Clear();
            foreach(IUserProfile usr in _userProfileDAO.GetAllUserProfile())
            {
                UserProfiles.Add(usr);
            }
        }

        private void Modify(IUserProfile usr)
        {
            _userProfileDAO.ModifyUserProfile(usr);
            SelectedUserProfile = null;
        }

        private void Add(IUserProfile obj)
        {
            _userProfileDAO.AddUserProfile(obj);
        }

        private void Delete(IUserProfile obj)
        {
            _userProfileDAO.DeleteUserProfile(obj);
        }

        private void Cancel()
        {
            _selectedUserProfile = null;
        }
        #endregion Methods

        #region Private Variables
        private string _myProperty = "User Profile Page";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand<IUserProfile> _addCommand;
        private RelayCommand<IUserProfile> _editCommand;
        private RelayCommand<IUserProfile> _deleteCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _loadCommand;
        private ObservableCollection<IUserProfile> _userProfile = new ObservableCollection<IUserProfile>();
        private UserProfileDataProvider _userProfileDAO = new UserProfileDataProvider();
        private IUserProfile _selectedUserProfile = null;
        #endregion Private Variables
    }
}
