using GalaSoft.MvvmLight;
using StoreApp.Model;
using System;
using System.Windows.Controls;
using StoreApp.Helpers;
using GalaSoft.MvvmLight.CommandWpf;
using StoreApp.Services;

namespace StoreApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _loadedCommand;
        private INavigationService<NavigationPage> _navigationService;

        public MainViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
            LoadedCommand = new RelayCommand(LoadHomePage);
        }

        public RelayCommand LoadedCommand
        {
            get => _loadedCommand;

            set => Set(ref _loadedCommand, value); 
        }
        private void LoadHomePage()
        {
            //_navigationService.NavigateTo("Home");
            _navigationService.NavigateTo("SignUp");
        }
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

    }
}