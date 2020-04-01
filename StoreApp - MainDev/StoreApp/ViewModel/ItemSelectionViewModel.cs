using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.BusinessLogicLayer;
using StoreApp.Model;
using StoreApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace StoreApp.ViewModel
{
    public class ItemSelectionViewModel: ViewModelBase
    {
        private RelayCommand _homeCommand;
        private RelayCommand _showCartCommand;
        private INavigationService<NavigationPage> _navigationService;
        private string _itemSelectionText = "Item Selection";

        public ItemSelectionViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            cartManager = new CartManager();
            productManager = new ProductManager();
            AddToCartCommand = new RelayCommand<BaseItem>((obj) => AddToCart(obj));
            ShowCartCommand = new RelayCommand(ShowCart);
            HomeCommand = new RelayCommand(Home);
            categoryValues = new ObservableCollection<string>(productManager.GetCategories());
            units = new ObservableCollection<string>(productManager.GetUnits());

        }

        /// <summary>
        /// Add operation of the AddToCart.
        /// Operation that will be performormed on the control click.
        /// </summary>
        /// <param name="obj"></param>
        public void LoadItems(string category)
        {
            productManager.GetProducts(category);
        }

        /// <summary>
        /// Add operation of the AddToCart.
        /// Operation that will be performormed on the control click.
        /// </summary>
        /// <param name="obj"></param>
        public void AddToCart(BaseItem obj)
        {
            if (!_dictShopItems.ContainsKey(obj.ItemId.ToString()))
                _dictShopItems.Add(obj.ItemId.ToString(), obj);
            ItemsCount = _dictShopItems.Count;
        }

        private void ShowCart()
        {
            _navigationService.NavigateTo("ShowCartView");
        }
        private void Home()
        {
            _navigationService.NavigateTo("Home");
        }
        #region Public Properties

        public RelayCommand HomeCommand
        {
            get => _homeCommand;
            set => Set(ref _homeCommand, value);
        }
        public RelayCommand ShowCartCommand
        {
            get => _showCartCommand;
            set => Set(ref _showCartCommand, value);
        }
        public string ItemSelectionText
        {
            get => _itemSelectionText;

            set => Set(ref _itemSelectionText, value);
        }
        public string SelectedValue
        {
            get => selectedValue;
            set
            {
                Set<string>(() => this.SelectedValue, ref selectedValue, value);
                _freshItems = new ObservableCollection<IFreshItems>(productManager.GetProducts(selectedValue));
                if (_dictShopItems.Count > 0)
                {
                    foreach (BaseItem item in _freshItems)
                    {
                        if (_dictShopItems.ContainsKey(item.ItemId.ToString()))
                        {
                            item.Quantity = _dictShopItems[item.ItemId.ToString()].Quantity;
                            item.Measure = _dictShopItems[item.ItemId.ToString()].Measure;
                        }
                    }
                }
                RaisePropertyChanged("FreshItems");
            }
        }

        public ObservableCollection<string> FreshCategory
        {
            get => categoryValues;
            set
            {
                Set<ObservableCollection<string>>(() => this.FreshCategory, ref categoryValues, value);
                RaisePropertyChanged("FreshCategory");
            }
        }

        public ObservableCollection<string> FreshUnits
        {
            get => units;
            set
            {
                Set<ObservableCollection<string>>(() => this.FreshUnits, ref units, value);
                RaisePropertyChanged("FreshUnits");
            }
        }

        public ObservableCollection<IFreshItems> FreshItems
        {
            get => _freshItems;
            set
            {
                Set<ObservableCollection<IFreshItems>>(() => this.FreshItems, ref _freshItems, value);
                RaisePropertyChanged("FreshItems");
            }
        }

        public string FreshItemValue
        {
            get => freshItemValue;
            set
            {
                Set<string>(() => this.FreshItemValue, ref freshItemValue, value);
                RaisePropertyChanged();
            }
        }

        public int ItemsCount
        {
            get => _ItemsCount;
            set
            {
                Set<int>(() => this.ItemsCount, ref _ItemsCount, value);
                RaisePropertyChanged("ItemsCount");
            }
        }

        public RelayCommand<BaseItem> AddToCartCommand { get; set; }
        #endregion Public Properties

        #region Private Variables
        private readonly CartManager cartManager;
        private readonly ProductManager productManager;
        private string selectedValue;
        private string freshItemValue;
        private ObservableCollection<IFreshItems> _freshItems = null;
        private ObservableCollection<string> categoryValues = null;
        private ObservableCollection<string> units = null;
        private Dictionary<string, BaseItem> _dictShopItems = new Dictionary<string, BaseItem>();
        private int _ItemsCount;
        #endregion Private Variables
    }
}
