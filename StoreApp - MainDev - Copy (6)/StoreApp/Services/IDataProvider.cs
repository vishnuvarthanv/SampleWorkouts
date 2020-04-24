using StoreApp.BusinessLogicLayer;

using System.Collections.Generic;

namespace StoreApp.Services
{
    public interface IDataProvider
    {
        bool Delete(Items item);

        List<Items> GetAllItems();

        Items GetItemById(string id);

        bool Insert(Items Item);

        bool Update(Items Item);

        List<Categories> GetCategories();

        List<Units> GetUnits();
    }
}