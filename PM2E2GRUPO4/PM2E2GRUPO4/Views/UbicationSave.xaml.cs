using PM2E2GRUPO4.Clase;
using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicationSave : ContentPage
    {
        List<sitios> service;
        RestService restService;
        double lat, lon;

        public UbicationSave()
        {
            InitializeComponent();
            restService = new RestService();

        }

        protected async override void OnAppearing()
        { 
            service = await restService.GetRepositoriesAsync(DataConstants.urlGet); 
            ListStudent.ItemsSource = service; 
        }

        private  void ver_Clicked(object sender, EventArgs e)
        {
            
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var obj = (sitios)e.Item;

            lat = obj.latitud;
            lon = obj.longitud;

            if (!string.IsNullOrEmpty(obj.id.ToString()))
            { 

                    var ubication = new sitios
                    {
                        id = obj.id,
                        descripcion = obj.descripcion,
                        latitud = obj.latitud,
                        longitud = obj.longitud,
                    };

                    var detalles = new ViewUbication(lat,lon);
                    detalles.BindingContext = ubication;
                    await Navigation.PushAsync(detalles); 
            }
             
        }


        private async void ListStudent_SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (sitios)e.SelectedItem;

            lat = obj.latitud;
            lon = obj.longitud;

            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {

                var ubication = new sitios
                {
                    id = obj.id,
                    descripcion = obj.descripcion,
                    latitud = obj.latitud,
                    longitud = obj.longitud,
                };

                var detalles = new ViewUbication(lat, lon);
                detalles.BindingContext = ubication;
                await Navigation.PushAsync(detalles);
            }

        }
    }
}