using StoreApp.Model;
using StoreApp.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region Private Variables
        ProductRepository productRepository = null;
        #endregion
    }
}
