using StoreApp.Model.Interfaces;
using System.Collections.Generic;

namespace StoreApp.RepositoryLayer
{
    public interface IDataProvider
    {
        //bool Delete(IFriend friend);

        //List<IFriend> GetAllFriends();

        //IFriend GetFriendById(string id);

        bool Insert(IUserProfile userProfile);

        //bool Update(IFriend friend);
    }
}