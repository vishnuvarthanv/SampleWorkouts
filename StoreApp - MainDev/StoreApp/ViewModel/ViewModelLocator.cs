using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using StoreApp.Services;
using System;

namespace StoreApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static bool initialized; //New
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {

            if (initialized) { return; }//New
            initialized = true;//New

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();//New
            SimpleIoc.Default.Register<ItemSelectionViewModel>();//New
            SimpleIoc.Default.Register<ShowCartViewModel>();//New
            SimpleIoc.Default.Register<HomeViewModel>();//New
            SetupNavigation();//New 
        }
        private void SetupNavigation()//New
        {
            var navigationService = new NavigationService<NavigationPage>();
            navigationService.ConfigurePages();
            SimpleIoc.Default.Register<INavigationService<NavigationPage>>(() => navigationService);
        }


        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ItemSelectionViewModel ItemSelectionViewModel => ServiceLocator.Current.GetInstance<ItemSelectionViewModel>();

        public ShowCartViewModel ShowCartViewModel => ServiceLocator.Current.GetInstance<ShowCartViewModel>();

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}