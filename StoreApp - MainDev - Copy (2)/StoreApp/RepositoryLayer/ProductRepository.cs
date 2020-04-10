using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.RepositoryLayer
{
   public class ProductRepository
    {

        internal List<IFreshItems> GetVegitables()
        {
            List<IFreshItems> vegItems = new List<IFreshItems>();

            Vegitables veg = new Vegitables();
            veg.ItemId = 100;
            veg.ItemName = "Beans";
            vegItems.Add(veg);
            Vegitables veg1 = new Vegitables();
            veg1.ItemId = 101;
            veg1.ItemName = "Cabbage";
            vegItems.Add(veg1);
            Vegitables veg2 = new Vegitables();
            veg2.ItemId = 102;
            veg2.ItemName = "Cauliflower";
            vegItems.Add(veg2);
            return vegItems;
        }

        internal List<IFreshItems> GetFruits()
        {
            List<IFreshItems> fruitItems = new List<IFreshItems>() ;

            Fruits fruit = new Fruits();
            fruit.ItemId = 200;
            fruit.ItemName = "Apple";
            fruitItems.Add(fruit);
            Fruits fruit1 = new Fruits();
            fruit1.ItemId = 201;
            fruit1.ItemName = "Orange";
            fruitItems.Add(fruit1);
            Fruits fruit2 = new Fruits();
            fruit2.ItemId = 202;
            fruit2.ItemName = "Grapes";
            fruitItems.Add(fruit2);
            return fruitItems;
        } 

        internal List<IFreshItems> GetGroceries()
        {
            List<IFreshItems> groceryItems = new List<IFreshItems>();

            Groceries grocery = new Groceries();
            grocery.ItemId = 300;
            grocery.ItemName = "Rice Matta Unda";
            Groceries grocery1 = new Groceries();
            grocery1.ItemId = 301;
            grocery1.ItemName = "Rice Matta Vadi";
            Groceries grocery2 = new Groceries();
            grocery2.ItemId = 302;
            grocery2.ItemName = "Puttu flour";
            Groceries grocery3 = new Groceries();
            grocery3.ItemId = 303;
            grocery3.ItemName = "Pappad";
            Groceries grocery4 = new Groceries();
            grocery4.ItemId = 304;
            grocery4.ItemName = "Biriyani RIce";
            groceryItems.Add(grocery);
            groceryItems.Add(grocery1);
            groceryItems.Add(grocery2);
            groceryItems.Add(grocery3);
            groceryItems.Add(grocery4);
            return groceryItems;
        }
    }
}
