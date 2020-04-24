using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Services;

namespace StoreApp.ViewModel
{
    public class ShowCartViewModel: ViewModelBase
    {
        private RelayCommand _homeCommand;
        private INavigationService<NavigationPage> _navigationService;
        private string _showCartText = "Show Cart";

        public ShowCartViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            HomeCommand = new RelayCommand(LoadHome);
        }

        private void LoadHome()
        {
            _navigationService.NavigateTo("ItemSelectionView");
        }

        public RelayCommand HomeCommand
        {
            get => _homeCommand;
            set => Set(ref _homeCommand, value);
        }
        public string ShowCartText
        {
            get => _showCartText;
            set => Set(ref _showCartText, value);
        }
    }
}
