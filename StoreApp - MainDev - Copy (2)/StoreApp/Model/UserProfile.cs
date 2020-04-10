using System;
using GalaSoft.MvvmLight;
using StoreApp.Model.Interfaces;

namespace StoreApp.Model
{
    public class UserProfile : ObservableObject, IUserProfile
    {
        private string _location;
        private string _address;
        private string _mobile;
        private string _email;
        private string _name;

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
    }
}
