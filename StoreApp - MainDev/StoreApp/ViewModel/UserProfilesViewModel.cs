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
            EditCommand = new RelayCommand(Modify, SelectedUserProfile != null);
            AddCommand = new RelayCommand(Add, SelectedUserProfile != null);
            DeleteCommand = new RelayCommand(Delete, SelectedUserProfile != null);
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
                if(SelectedUserProfile!=null)
                {
                    this.Name = SelectedUserProfile.Name;
                    this.Email = SelectedUserProfile.Email;
                    this.Mobile = SelectedUserProfile.Mobile;
                    this.Address = SelectedUserProfile.Address;
                    this.Location = SelectedUserProfile.Location;
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        public string Mobile
        {
            get { return _mobile; }
            set { Set(ref _mobile, value); }
        }
        public string Address
        {
            get { return _address; }
            set { Set(ref _address, value); }
        }
        public string Location
        {
            get { return _location; }
            set { Set(ref _location, value); }
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
            set => Set(ref _editCommand, value); 
        }

        public RelayCommand AddCommand
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

        private void Modify()
        {
            IUserProfile usr = new UserProfile();
            usr.Name = Name;
            usr.Email = Email;
            usr.Mobile = Mobile;
            usr.Address = Address;
            usr.Location = Location;
            _userProfileDAO.ModifyUserProfile(usr);
            SelectedUserProfile = null;
            Clear();
        }

        private void Add()
        {
            IUserProfile usr = new UserProfile();
            usr.Name = Name;
            usr.Email = Email;
            usr.Mobile = Mobile;
            usr.Address = Address;
            usr.Location = Location;
            _userProfileDAO.AddUserProfile(usr);
            SelectedUserProfile = null;
            Clear();
        }

        private void Delete()
        {
            IUserProfile usr = new UserProfile();
            usr.Name = Name;
            usr.Email = Email;
            usr.Mobile = Mobile;
            usr.Address = Address;
            usr.Location = Location;
            _userProfileDAO.DeleteUserProfile(usr);
            SelectedUserProfile = null;
            Clear(); 
        }

        private void Cancel()
        {
            SelectedUserProfile = null;
            Clear();
        }

        public void Clear()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Mobile = string.Empty;
            this.Address = string.Empty;
            this.Location = string.Empty;
            OnLoad();
        }
        #endregion Methods

        #region Private Variables
        private string _myProperty = "User Profile Page";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _loadCommand;
        private ObservableCollection<IUserProfile> _userProfile = new ObservableCollection<IUserProfile>();
        private UserProfileDataProvider _userProfileDAO = new UserProfileDataProvider();
        private IUserProfile _selectedUserProfile = null;
        private string _location;
        private string _address;
        private string _mobile;
        private string _email;
        private string _name;
        #endregion Private Variables
    }
}
