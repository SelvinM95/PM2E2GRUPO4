using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2GRUPO4.Models
{
    public class Configuraciones
    {
        public const String IDFoursquare = "OB4SKTS5BHX00RUHLLWX3EOLYZTSH4ZXTSQXH5YLK1ISAC3Q";
        public const String SecreteFoursquare = "O4GXCN10PCDTWHOSO3XBGHMKDYVC5BHEU2ZFJCE5BYFGQK12";

        public const String apifoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
    }

    public class Sitios
    {
        public static String getUrl(Double latitud, Double longitud)
        {
            return String.Format(Configuraciones.apifoursquare, latitud, longitud, Configuraciones.IDFoursquare, Configuraciones.SecreteFoursquare, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
