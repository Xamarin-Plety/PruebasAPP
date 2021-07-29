using PruebasAPP.Services;
using PruebasAPP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebasAPP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            if (App.Current.Properties.ContainsKey("IsLoggedIn"))
            {
                if ((bool)App.Current.Properties["IsLoggedIn"])
                {
                    MainPage = new AppShell();
                }
                else
                {
                    MainPage = new LoginPage();
                }
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
