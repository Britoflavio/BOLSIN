using Bolsines.Datos_Prueba;
using Bolsines.Entidades;
using Bolsines.Interfaces.Sistemas_Externos;

namespace Bolsines.Interfaces
{
    // Como usamos Leaflet, esta clase debería llamarse InterfazLeaflet, pero
    // la dejamos así para no cambiar el nombre de la clase en los diagramas
    public class InterfazGoogleMaps
    {
        // Atributos
        private string apiKeyGoogleMaps;
        private ServidorGoogleMaps servidorGoogleMaps;

        // Constructor
        public InterfazGoogleMaps()
        {
            this.apiKeyGoogleMaps = DatosPrueba.getAPIKeyGoogleMaps();
            this.servidorGoogleMaps = DatosPrueba.cargarServidorGoogleMaps();
        }

        // Métodos
        public void mostrarBolsinesEnMapa(
            List<(
                Bolsin bolsin,
                int numeroBolsin,
                (double latitud, double longitud) ubicacion,
                DateTime fechaHoraUbicacion
            )> localizacionBolsines
        )
        {
            var localizacionBolsinesSinObjeto =
                new List<(
                    int numeroBolsin,
                    (double latitud, double longitud) ubicacion,
                    DateTime fechaHoraUbicacion
                )>();

            foreach (var localizacion in localizacionBolsines)
            {
                localizacionBolsinesSinObjeto.Add(
                    (
                        localizacion.numeroBolsin,
                        localizacion.ubicacion,
                        localizacion.fechaHoraUbicacion
                    )
                );
            }

            this.servidorGoogleMaps.mostrarBolsinesEnMapa(localizacionBolsinesSinObjeto);
        }
    }
}
