using StoreApp.Model;
using StoreApp.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Services;
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
        public List<Items> GetItems(Categories cat)
        {
            try
            {
                return dp.GetAllItems().Where(x => x.Cat_Id == cat.CategoryId).ToList();
            }catch(Exception ex)
            {
                return null;
            }
        }


        public IList<Categories> GetCategory()
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

        public IList<Units> GetUnit()
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

    public class Categories
    {
        public string CategoryName { get; set; }

        public string CategoryId { get; set; }
    }

    public class Units
    {
        public string UnitName { get; set; }

        public string UnitId { get; set; }
    }

    public class Items
    {
        public string Item_Id { get; set; }

        public string Item_Name { get; set; }

        public string Cat_Id { get; set; }

        public string Unit_Id { get; set; }

        public float Price { get; set; }

        public string Start_Date { get; set; }

        public string End_Date { get; set; }

        public string Active { get; set; }
    }
}
