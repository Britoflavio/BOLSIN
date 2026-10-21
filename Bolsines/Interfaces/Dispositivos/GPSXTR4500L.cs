using System.Globalization;
using Bolsines.Utilidades;

namespace Bolsines.Interfaces.Dispositivos
{
    public class GPSXTR4500L
    {
        // Atributos (no van en el diagrama de clases)
        private int numeroBolsin;

        // Constructor (no va en el diagrama de clases)
        public GPSXTR4500L(int numeroBolsin)
        {
            this.numeroBolsin = numeroBolsin;
        }

        // Métodos
        public string? getBolsinLocation(string apiKey, int numeroBolsin, string codigoCMOrigen)
        {
            // Se podría agregar una validación de la API Key y del código de
            // la comisión médica de origen
            if (numeroBolsin == this.numeroBolsin)
            {
                var latitudMinima = -54.79268494188909;
                var latitudMaxima = -21.175298717100606;
                var longitudMinima = -73.45192942228589;
                var longitudMaxima = -53.53492864973965;
                double latitud,
                    longitud;

                do
                {
                    latitud =
                        latitudMinima + (latitudMaxima - latitudMinima) * new Random().NextDouble();
                    longitud =
                        longitudMinima
                        + (longitudMaxima - longitudMinima) * new Random().NextDouble();
                } while (!Localizacion.EstaEnArgentina(latitud, longitud));

                var fechaHoraActualUTC = DateTime.UtcNow;
                var fechaHoraActualFormateada = fechaHoraActualUTC.ToString("yyyy-MM-ddTHH:mm:ssZ");

                var localizacion =
                    "{"
                    + $"\"numeroBolsin\": {numeroBolsin},"
                    + $"\"latitud\": {latitud.ToString(CultureInfo.InvariantCulture)},"
                    + $"\"longitud\": {longitud.ToString(CultureInfo.InvariantCulture)},"
                    + $"\"fechaHoraUltimaActualizacion\": \"{fechaHoraActualFormateada}\""
                    + "}";

                return localizacion;
            }
            else
            {
                return null;
            }
        }
    }
}
