using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using WotAnalizator.Pages;
using WotAnalizator.Services;
using WotAnalizator.ViewModel;
using Xamarin.Forms;

namespace WotAnalizator
{
    public class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public App()
        {
            NavigationService nav;
            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                nav = new NavigationService();
                nav.Configure(ViewModelLocator.AboutPage, typeof(AboutPage));
                nav.Configure(ViewModelLocator.MenuPage, typeof(MenuPage));
                nav.Configure(ViewModelLocator.CopyrightPage, typeof(CopyrightPage));
                nav.Configure(ViewModelLocator.MainPage, typeof(MainPage));
                SimpleIoc.Default.Register<INavigationService>(() => nav);
            }
            else
            {
                nav = SimpleIoc.Default.GetInstance<NavigationService>();
            }

            var firstPage = new NavigationPage(new MenuPage());

            nav.Initialize(firstPage);

            MainPage = firstPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
