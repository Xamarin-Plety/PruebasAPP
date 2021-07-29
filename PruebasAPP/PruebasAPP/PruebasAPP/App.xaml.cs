using PruebasAPP.Models;
using PruebasAPP.Services;
using PruebasAPP.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebasAPP
{
    public partial class App : Application
    {
        public static App Current;
        public static int iIdEmpleado { get; set; }
        public static int iIdEmpresa { get; set; }
        public static MemoryStream msFoto { get; set; }
        public static cEmpleado oEmpleado { get; set; }

        public App()
        {
            InitializeComponent();

            Current = this;
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
