using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.RepositoryLayer
{
  public  class CartRepository
    {

        //Maintains the patient collection locally
        private static List<Cart> cartItems = new List<Cart>();

        /// <summary>
        /// Add a patient 
        /// </summary>
        internal void AddToCart(Cart cart)
        {
            cartItems.Add(cart);
        }

    }
}
