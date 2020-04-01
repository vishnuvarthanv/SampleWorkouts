using StoreApp.Model;
using StoreApp.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogicLayer
{
   public class CartManager
    {

        #region Constructors
        
        public CartManager()
        {
            CartRepository cartRepository = new CartRepository();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add Patient
        /// </summary>
        /// <param name="patient">Patient to add</param>
        /// <returns></returns>
        public bool AddToCart(Cart cart)
        {
            //Search if the patient exists and if not add the patient.
            cartRepository.AddToCart(cart);
                return true;
        }
        #endregion

        #region Private Variables
        CartRepository cartRepository = null;
        #endregion
    }
}
