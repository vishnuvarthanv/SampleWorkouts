using StoreApp.Model;
using StoreApp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.RepositoryLayer
{
    public class UserProfileDataProvider
    {
        IList<IUserProfile> _userProfile = new List<IUserProfile>();
        public UserProfileDataProvider()
        {
            /*
             *             return new[] 
            {
                new Homework() { Course = "Vak 1", DueDate = DateTime.Now.AddDays(5), Summary = "Een kleine uitleg" },
                new Homework() { Course = "Vak 1", DueDate = DateTime.Now.AddDays(6), Summary = "Een kleine uitleg", Completed =  true },
                new Homework() { Course = "Vak 2", DueDate = DateTime.Now.AddDays(15), Summary = "Een kleine uitleg" },
                new Homework() { Course = "Vak 2", DueDate = DateTime.Now.AddDays(1), Summary = "Een kleine uitleg" },
                new Homework() { Course = "Vak 3", DueDate = DateTime.Now.AddDays(22), Summary = "Een kleine uitleg" }
            };
             */
            IList<IUserProfile> userProf = new List<IUserProfile>
            {
                new UserProfile(){ Name = "Vishnuvarthan1", Mobile="985781251", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan2", Mobile="985781252", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan3", Mobile="985781253", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan4", Mobile="985781254", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan5", Mobile="985781255", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan6", Mobile="985781256", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan7", Mobile="985781257", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan8", Mobile="985781258", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan9", Mobile="985781259", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan10", Mobile="985781210", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar1", Mobile="985781211", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar2", Mobile="985781212", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar3", Mobile="985781213", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar4", Mobile="985781214", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar5", Mobile="985781215", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar6", Mobile="985781216", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar7", Mobile="985781217", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar8", Mobile="985781218", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar9", Mobile="985781219", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Kumar10", Mobile="985781220", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" },
                new UserProfile(){ Name = "Vishnuvarthan11", Mobile="985781221", Email="vv@gmail.com", Location="Location", Address="Flat 8, Blue Home, Adyar, Chennai" }
            };
            _userProfile = userProf;
        }
        public bool AddUserProfile(IUserProfile userProfile)
        {
            if(userProfile!=null)
            {
                _userProfile.Add(userProfile);
                return true;
            }
            return false;
        }

        public bool ModifyUserProfile(IUserProfile userProfile)
        {
            if (userProfile != null)
            {
                IUserProfile user = _userProfile.Where(x => x.Name == userProfile.Name).First();
                user.Mobile = userProfile.Mobile;
                user.Location = userProfile.Location;
                user.Email = userProfile.Email;
                user.Address = userProfile.Address;
                return true;
            }
            return false;
        }

        public bool DeleteUserProfile(IUserProfile userProfile)
        {
            if (userProfile != null)
            {
                IUserProfile user = _userProfile.Where(x => x.Name == userProfile.Name).First();
                _userProfile.Remove(userProfile);
                return true;
            }
            return false;
        }

        public IList<IUserProfile> GetAllUserProfile()
        {
            return _userProfile;
        }
    }
}
