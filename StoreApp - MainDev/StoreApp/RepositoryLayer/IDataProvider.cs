using StoreApp.Model.Interfaces;
using System.Collections.Generic;

namespace StoreApp.RepositoryLayer
{
    public interface IDataProvider
    {
        //bool Insert(IUserProfile userProfile);
        bool Delete(IItems item);

        List<IItems> GetAllItems();

        IItems GetItemById(string id);

        bool Insert(IItems Item);

        bool Update(IItems Item);

        List<ICategory> GetCategories();

        List<IUnits> GetUnits();
    }
}