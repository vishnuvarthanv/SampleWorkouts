using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.BusinessLogicLayer;
using StoreApp.Model.Interfaces;
using StoreApp.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace StoreApp.ViewModel
{
    public class MasterPagesViewModel : ViewModelBase
    {
        #region Constructor
        public MasterPagesViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            productManager = new ProductManager();
            Units = new ObservableCollection<IUnits>(productManager.GetUnit());
            CategoryValues = new ObservableCollection<ICategory>(productManager.GetCategory());
        }
        #endregion Constructor

        public RelayCommand LoadedCommand
        {
            get => _loadedCommand;

            set => Set(ref _loadedCommand, value);
        }

        public ICategory SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                Set(ref _selectedCategory, value);
                FreshItems = new ObservableCollection<IItems>(productManager.GetItems(_selectedCategory));
                SelectedItem = FreshItems?.First();
            }
        }

        public ObservableCollection<IItems> FreshItems
        {
            get => _freshItems;
            set => Set(ref _freshItems, value);
        }

        public IItems SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                SelectedUnits = Units.Where(x => x.UnitId == _selectedItem.Unit_Id).First();
            }
        }

        public ObservableCollection<ICategory> CategoryValues
        {
            get => _categoryValues;
            set => Set(ref _categoryValues, value);
        }
        public ObservableCollection<IUnits> Units
        {
            get => _units;
            set => Set(ref _units, value);
        }

        public IUnits SelectedUnits
        {
            get => _selectedUnits;
            set => Set(ref _selectedUnits, value);
        }
        private void LoadMasterPages()
        {
            //_navigationService.NavigateTo("Home");
            _categoryValues = new ObservableCollection<ICategory>(productManager.GetCategory());
        }

        #region Private Variables
        private string _myProperty = "Master Page";
        private INavigationService<NavigationPage> _navigationService;
        private ProductManager productManager;
        private RelayCommand _loadedCommand;
        private ObservableCollection<ICategory> _categoryValues = null;
        private ICategory _selectedCategory;
        private ObservableCollection<IItems> _freshItems = null;
        private IItems _selectedItem;
        private ObservableCollection<IUnits> _units = null;
        private IUnits _selectedUnits;
        #endregion Private Variables
    }
}
