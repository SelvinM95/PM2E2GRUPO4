using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2E2GRUPO4.Clase
{
    public class RestService
    {
        HttpClient cliente;
    

        public RestService()
        {
        cliente = new HttpClient();

        if (Device.RuntimePlatform == Device.UWP)
        {
            cliente.DefaultRequestHeaders.Add("User-Agent", "");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        }
        }

        public async Task<List<sitios>> GetRepositoriesAsync(string url)
        {
            List<sitios> lista = null;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string img = await respuesta.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<sitios>>(img);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error", ex.Message);
            }

            return lista;
        }

        public async Task<T> executeRequestPost<T>(object image)
        {


            Uri urlBase = new Uri(DataConstants.urlBase);
            cliente.BaseAddress = urlBase;


            string jsonData = JsonConvert.SerializeObject(image);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await cliente.PostAsync(DataConstants.urlPost1, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }



    }
}
