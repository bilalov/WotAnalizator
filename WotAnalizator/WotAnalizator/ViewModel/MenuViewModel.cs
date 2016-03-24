using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WotAnalizator.ViewModel;

namespace WotAnalizator.ViewModel
{
    public class MenuViewModel
    {
        private readonly INavigationService _navigationService;
        public MenuViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            MoveToAboutViewCommand = new RelayCommand(() => { _navigationService.NavigateTo(ViewModelLocator.AboutPage); });
            MoveToMainViewCommand = new RelayCommand(() => { _navigationService.NavigateTo(ViewModelLocator.MainPage); });
            MoveToCopyrightCommand = new RelayCommand(() => { _navigationService.NavigateTo(ViewModelLocator.CopyrightPage); });

        }

        public ICommand MoveToAboutViewCommand { get; set; }
        public ICommand MoveToMainViewCommand { get; set; }
        public ICommand MoveToCopyrightCommand { get; set; }
    }
}
