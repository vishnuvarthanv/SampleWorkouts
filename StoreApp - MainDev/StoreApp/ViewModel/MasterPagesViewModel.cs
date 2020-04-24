using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.BusinessLogicLayer;
using StoreApp.Model;
using StoreApp.Services;

namespace StoreApp.ViewModel
{
    public class MasterPagesViewModel : ViewModelBase
    {
        #region Constructor
        public MasterPagesViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            productManager = new ProductManager();
            //LoadedCommand = new RelayCommand(LoadMasterPages);
            Units = new ObservableCollection<Units>(productManager.GetUnit());
            CategoryValues = new ObservableCollection<Categories>(productManager.GetCategory());
        }
        #endregion Constructor

        public RelayCommand LoadedCommand
        {
            get => _loadedCommand;

            set => Set(ref _loadedCommand, value);
        }

        public Categories SelectedCategory
        {
            get => _selectedCategory;
            //set => Set(ref _selectedCategory, value);
            set
            {
                Set(ref _selectedCategory, value);
                FreshItems = new ObservableCollection<Items>(productManager.GetItems(_selectedCategory));
                SelectedItem = FreshItems?.First();
            }
        }

        public ObservableCollection<Items> FreshItems
        {
            get => _freshItems;
            set => Set(ref _freshItems, value);
        }

        public Items SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                SelectedUnits = Units.Where(x => x.UnitId == _selectedItem.Unit_Id).First();
            }
        }

        public ObservableCollection<Categories> CategoryValues
        {
            get => _categoryValues;
            set => Set(ref _categoryValues, value);
        }
        public ObservableCollection<Units> Units
        {
            get => _units;
            set => Set(ref _units, value);
        }

        public Units SelectedUnits
        {
            get => _selectedUnits;
            set => Set(ref _selectedUnits, value);
        }
        private void LoadMasterPages()
        {
            //_navigationService.NavigateTo("Home");
            _categoryValues = new ObservableCollection<Categories>(productManager.GetCategory());
        }

        #region Private Variables
        private string _myProperty = "Master Page";
        private INavigationService<NavigationPage> _navigationService;
        private ProductManager productManager;
        private RelayCommand _loadedCommand;
        private ObservableCollection<Categories> _categoryValues = null;
        private Categories _selectedCategory;
        private ObservableCollection<Items> _freshItems = null;
        private Items _selectedItem;
        private ObservableCollection<Units> _units = null;
        private Units _selectedUnits;
        #endregion Private Variables
    }
}
