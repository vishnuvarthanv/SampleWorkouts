using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    public class HomeViewModel: ViewModelBase
    {
        private string _myProperty = "MainPageText";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand _itemSelectionCommand;

        private RelayCommand _showCartCommand;

        public HomeViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            ItemSelectionCommand = new RelayCommand(LoadItemSelection);
            ShowCartCommand = new RelayCommand(LoadShowCartCommand);
        }
        public string MainPageText
        {
            get => _myProperty;
            set => Set(ref _myProperty, value);
        }

        private void LoadItemSelection()
        {
            _navigationService.NavigateTo("ItemSelectionView");
        }

        private void LoadShowCartCommand()
        {
            _navigationService.NavigateTo("ShowCartView");
        }

        public RelayCommand ItemSelectionCommand
        {
            get=> _itemSelectionCommand;
            set
            {
                Set( ref _itemSelectionCommand, value);
            }
        }

        public RelayCommand ShowCartCommand
        {
            get => _showCartCommand;
            set
            {
                Set(ref _showCartCommand, value);
            }
        }

    }
}
