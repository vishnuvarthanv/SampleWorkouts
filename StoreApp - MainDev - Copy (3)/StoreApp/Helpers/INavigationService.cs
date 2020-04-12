using System;
using System.Windows.Navigation;

namespace StoreApp.Helpers
{
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri uri);
        void GoBack();
    }
}
