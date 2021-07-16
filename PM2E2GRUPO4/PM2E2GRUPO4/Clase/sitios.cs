using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2GRUPO4.Clase
{
    public class sitios
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("descripcion")]
        public String descripcion { get; set; }

        [JsonProperty("latitud")]
        public Double latitud { get; set; }

        [JsonProperty("longitud")]
        public Double longitud { get; set; }

        [JsonProperty("image")]
        public byte[] image { get; set; } 
    }
}
