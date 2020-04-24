using StoreApp.BusinessLogicLayer;
using StoreApp.Model.Interfaces;
using System.Collections.Generic;

namespace StoreApp.RepositoryLayer
{
    public interface IDataProvider
    {
        //bool Insert(IUserProfile userProfile);
        bool Delete(Items item);

        List<Items> GetAllItems();

        Items GetItemById(string id);

        bool Insert(Items Item);

        bool Update(Items Item);

        List<Categories> GetCategories();

        List<Units> GetUnits();
    }
}