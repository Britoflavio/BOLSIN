using System.Text.Json;

namespace Bolsines.Interfaces.Sistemas_Externos
{
    public class ServidorGoogleMaps
    {
        public void mostrarBolsinesEnMapa(
            List<(
                int numeroBolsin,
                (double latitud, double longitud) ubicacion,
                DateTime fechaHoraUbicacion
            )> localizacionBolsines
        )
        {
            var localizaciones = new List<object>();

            foreach (var localizacion in localizacionBolsines)
            {
                localizaciones.Add(
                    new
                    {
                        type = "Feature",
                        geometry = new
                        {
                            type = "Point",
                            coordinates = new double[]
                            {
                                localizacion.ubicacion.longitud,
                                localizacion.ubicacion.latitud,
                            },
                        },
                        properties = new { name = $"Bolsín {localizacion.numeroBolsin}" },
                    }
                );
            }

            string localizacionesJSON = JsonSerializer.Serialize(
                localizaciones,
                new JsonSerializerOptions { WriteIndented = true }
            );
            File.WriteAllText("wwwroot/localizaciones.json", localizacionesJSON);
        }
    }
}
