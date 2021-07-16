using Newtonsoft.Json;
using PM2E2GRUPO4.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PM2E2GRUPO4.Clase
{
    class ubicationManager
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<IEnumerable<sitios>> getCoutries(string URL)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<sitios>>(content);
            }

            return Enumerable.Empty<sitios>();
        }

        public async Task<IEnumerable<FourSquareModel.Venue>> getSites(string URL)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<FourSquareModel.Venue>>(content);
            }

            return Enumerable.Empty<FourSquareModel.Venue>();
        }
    }
}
