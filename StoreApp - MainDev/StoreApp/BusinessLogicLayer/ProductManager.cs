using StoreApp.Model;
using StoreApp.Model.Interfaces;
using StoreApp.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.BusinessLogicLayer
{
    public class ProductManager
    {
        #region Constructors

        public ProductManager()
        {
            productRepository = new ProductRepository();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add Patient
        /// </summary>
        /// <param name="patient">Patient to add</param>
        /// <returns></returns>
        public List<IFreshItems> GetProducts(string category)
        {
            if (category.Contains("Fruits"))
                return productRepository.GetFruits();
            else if (category.Contains("Vegitables"))
                return productRepository.GetVegitables();
            else if (category.Contains("Groceries"))
                return productRepository.GetGroceries();

            return null;
        }
        public IList<string> GetCategories()
        {
            return new List<string>()
                                    {
                                        "Fruits","Vegitables","Groceries"
                                    };
        }

        public IList<string> GetUnits()
        {
            return new List<string>()
                                    {
                                        "None","Gms","Kg","Packet"
                                    };
        }
        public List<IItems> GetItems(ICategory cat)
        {
            try
            {
                return dp.GetAllItems().Where(x => x.Cat_Id == cat.CategoryId).ToList();
            }catch(Exception ex)
            {
                return null;
            }
        }


        public IList<ICategory> GetCategory()
        {
            try
            {
                return dp.GetCategories();
            }
            catch(Exception  ex)
            {
                return null;
            }
        }

        public IList<IUnits> GetUnit()
        {
            try
            {
                return dp.GetUnits();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Private Variables
        ProductRepository productRepository = null;
        SqliteDataProvider dp = new SqliteDataProvider();
        #endregion
    }
}
