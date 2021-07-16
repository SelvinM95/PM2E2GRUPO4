using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using PM2E2GRUPO4.Clase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUbication : ContentPage
    {
        byte[] foto ;

        public NewUbication()
        {
            InitializeComponent(); 
        }

        protected async override void OnAppearing()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Failed", "Internet Conection Requeride", "OK");
            }
            else
            {
                try
                {
                    var locator = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(5)));

                    if (locator != null)
                    {
                        latitud.Text = locator.Latitude.ToString();
                        longitud.Text = locator.Longitude.ToString();
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    await DisplayAlert("Failed", fnsEx.Message, "OK");
                }
                catch (PermissionException pEx)
                {
                    await DisplayAlert("Failed", pEx.Message, "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Failed", ex.Message, "OK");
                }
            }
            
        }

        private  void Photo_Clicked(object sender, EventArgs e)
        {
           
        }

        public bool validarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(latitud.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(longitud.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(ubicacionC.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void tomar_Clicked(object sender, EventArgs e)
        {
            var cameraOptions = new StoreCameraMediaOptions();

            cameraOptions.PhotoSize = PhotoSize.Full;

            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(cameraOptions);

            foto = GetImageBytes(photo);

            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }
        }


        private byte[] GetImageBytes(MediaFile file)
        {
            byte[] ImageBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }

        private async void UbicationSave_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {

                var data = new sitios
                {
                    descripcion = ubicacionC.Text,
                    latitud = Convert.ToDouble(latitud.Text),
                    longitud = Convert.ToDouble(longitud.Text),
                    image = foto
                };

                HttpClient httpClient = new HttpClient();
                string url = "https://dockshare.webcindario.com/CRUD/CrearUbicacion.php?descripcion=" + data.descripcion + "&latitud=" + data.latitud + "&longitud=" + data.longitud + "&imagen=" + data.image + "";


                var jsonData = JsonConvert.SerializeObject(data);
                var contentJSON = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, contentJSON);

                await DisplayAlert("Registro", "Datos guardados correctamente", "Ok");
                latitud.Text = "";
                longitud.Text = "";
                ubicacionC.Text = "";
                Photo.Source = null;

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }

    }
}