using Newtonsoft.Json;
using PM2E2GRUPO4.Clase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUbication : ContentPage
    {
        double la, lo;

        public ViewUbication(double lat, double lon)
        {
            InitializeComponent();
            la = lat;
            lo = lon;
        }

        protected async override void OnAppearing()
        {
            ListSites.ItemsSource = await Models.Metodos.getSites(la, lo);

        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            var data = new sitios
            {
                id = Convert.ToInt32(idUbicacion.Text)
            };

            HttpClient httpClient = new HttpClient();
            string url = "https://dockshare.webcindario.com/CRUD/EliminarUbicacion.php";


            String jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PostAsync(url, new StringContent(jsonData));
            var json = response.Content.ReadAsStringAsync().Result;

            await DisplayAlert("Registro", "Datos eliminado Correctamente", "Ok");
            await Navigation.PopAsync();
        }

        private async void ver_Clicked(object sender, EventArgs e)
        {
            var location = new Location(la, lo);
            var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }

        private void ListSites_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }
    }
}