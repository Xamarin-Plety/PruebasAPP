using Newtonsoft.Json;
using PruebasAPP.ViewModels;
using PruebasAPP.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebasAPP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            ProcRegistraRoutes();

            if (Application.Current.Properties.ContainsKey("IsLoggedIn"))
            {
                if (!(bool)Application.Current.Properties["IsLoggedIn"])
                {
                    LogoutAsync();
                }
                else
                {
                    ProcCargaEmpleado();
                }
            }
        }

        public void ProcRegistraRoutes()
        {
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(SugerenciaDetallePage), typeof(SugerenciaDetallePage));
            //Routing.RegisterRoute(nameof(SugerenciaAclaracion), typeof(SugerenciaAclaracion));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //Routing.RegisterRoute(nameof(Views.HomeViews.PrincipalPage), typeof(Views.HomeViews.PrincipalPage));
            //Routing.RegisterRoute(nameof(Views.NominasView.NominasView), typeof(Views.NominasView.NominasView));
            //Routing.RegisterRoute(nameof(Views.HomeViews.BannerPage), typeof(Views.HomeViews.BannerPage));
            //Routing.RegisterRoute(nameof(Views.NotificacionesView.NotificacionesView), typeof(Views.NotificacionesView.NotificacionesView));
            //Routing.RegisterRoute(nameof(Views.NotificacionesView.Opciones.NotificacionDetalleView), typeof(Views.NotificacionesView.Opciones.NotificacionDetalleView));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {

            Application.Current.Properties["IsLoggedIn"] = false;
            Application.Current.Properties["iIdEmpleado"] = null;
            Application.Current.Properties["name"] = "";
            await Application.Current.SavePropertiesAsync();

            await Shell.Current.GoToAsync("//LoginPage");
        }

        public async Task<bool> LogoutAsync()
        {

            Application.Current.Properties["IsLoggedIn"] = false;
            Application.Current.Properties["iIdEmpleado"] = null;
            Application.Current.Properties["name"] = "";
            await Application.Current.SavePropertiesAsync();

            await Shell.Current.GoToAsync("//LoginPage");

            return JsonConvert.DeserializeObject<bool>("true");
        }

        public void ProcCargaEmpleado()
        {
            Byte[] imgFoto = { 0, 16, 104, 213 };
            Application.Current.Properties["IsLoggedIn"] = true;
            Application.Current.Properties["iIdEmpleado"] = 300;
            Application.Current.Properties["name"] = "300";
            Application.Current.Properties["imgFoto"] = imgFoto;
            //Application.Current.Properties["cUsuarioJerarquia"] = JsonConvert.SerializeObject(UsuarioJerarquia);
            Application.Current.SavePropertiesAsync();

            App.iIdEmpleado = (int)Application.Current.Properties["iIdEmpleado"];
            App.iIdEmpresa = 1;
        }


        protected override bool OnBackButtonPressed()
        {
            //if (Shell.Current.CurrentPage.Title != "Principal")
            //{
            //    //Shell.Current.GoToAsync($"//{nameof(Views.HomeViews.PrincipalPage)}");
            //    return true;
            //}

            return false;
        }
    }
}
