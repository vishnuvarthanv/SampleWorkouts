using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoreApp.Model.FreshEnum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StoreApp.Model
{
    public class Cart: ObservableObject
    {
        MyFreshEnum _category=0;
        private int _productId;
        private string _productName;
        private int _quantity;
        private int _units;

        public MyFreshEnum Category
        {
            get=> _category;
            set
            {
                Set<MyFreshEnum>(() => this.Category, ref _category, value);
            }
        }
        public int ProductId
        {
            get => _productId;
            set
            {
                Set<int>(() => this.ProductId, ref _productId, value);
            }
        }
        public string ProdcutName
        {
            get=>_productName;
            set
            {
                Set<string>(() => this.ProdcutName, ref _productName, value);
            }
        }
        public int Quantity
        {
            get=>_quantity;
            set
            {
                Set<int>(() => this.Quantity, ref _quantity, value);
            }
        }

        public int Units
        {
            get => _units;
            set
            {
                Set<int>(() => this.Units, ref _units, value);
            }
        }
    }
    public interface IFreshItems
    {
        int ItemId { get; set; }
        string ItemName { get; set; }
        decimal Quantity { get; set; }
        string Measure { get; set; }
    }

    public abstract class BaseItem : ObservableObject, IFreshItems, IDataErrorInfo
    {
        private int _itemId;
        private string _itemName;
        private decimal _quantity;
        private string _measure;
        private string error = string.Empty;
        private MyFreshEnum _itemCategories;
        public abstract MyFreshEnum ItemCategories
        {
            get;
        }
        public int ItemId
        {
            get => _itemId;
            set => Set<int>(() => this.ItemId, ref _itemId, value);
        }
        public string ItemName
        {
            get => _itemName;
            set => Set<string>(() => this.ItemName, ref _itemName, value);
        }

        public decimal Quantity
        {
            get => _quantity;
            set => Set<decimal>(() => this.Quantity, ref _quantity, value);
        }
        public string Measure
        {
            get => _measure;
            set => Set<string>(() => this.Measure, ref _measure, value);
        }

        private bool IsValidQty
        {
            get => this.Quantity > 0 ;
        }

        private bool IsValidUnits
        {
            get
            {
                bool result = true;
                if(string.IsNullOrEmpty(this.Measure))
                {
                    result = false;
                }
                else if(this.Measure == "None")
                {
                    result = false;
                }
                return result;
            }
        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        public string Error
        {
            get { return error; }
        }
        public string this[string columnName]
        {
            get
            {
                error = string.Empty;
                if (columnName == "Quantity" && !IsValidQty)
                {
                    error = "Quantity is required!";
                }
                else if (columnName == "Measure" )
                {
                    if (!IsValidUnits)
                    {
                        error = "Units is required!";
                    }
                    else if(IsTextNumeric(this.Quantity.ToString()))
                    {
                        error = "Only Numbers are allowed (0-9)";
                    }
                }
                return error;
            }
        }
    }
    public class Fruits : BaseItem
    {
        public override MyFreshEnum ItemCategories
        {
            get => MyFreshEnum.Fruits;
        }
    }
    public class Vegitables : BaseItem
    {
        public override MyFreshEnum ItemCategories
        {
            get => MyFreshEnum.Vegitables;
        }
    }

    public class Groceries : BaseItem
    {
        public override MyFreshEnum ItemCategories
        {
            get => MyFreshEnum.Grocerries;
        }
    }
}
