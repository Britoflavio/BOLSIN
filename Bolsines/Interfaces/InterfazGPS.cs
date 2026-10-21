using Bolsines.Datos_Prueba;
using Bolsines.Entidades;
using Bolsines.Interfaces.Patron_Adaptador;

namespace Bolsines.Interfaces
{
    public class InterfazGPS
    {
        // Atributos
        private List<string> apiKeyGPSTrackers;
        private List<(
            Bolsin bolsin,
            int numeroBolsin,
            (double latitud, double longitud) ubicacion,
            DateTime fechaHoraUbicacion
        )> localizacionesAdaptadas;
        private IAdaptadorGPS adaptadorGPS;

        // Constructor

        // public InterfazGPS(IAdaptadorGPS adaptadorGPS)
        // {
        //     this.apiKeyGPSTrackers = DatosPrueba.getAPIKeyGPST
        //     this.adaptadorGPS = adaptadorGPS;
        // }

        public InterfazGPS()
        {
            this.apiKeyGPSTrackers = DatosPrueba.getAPIKeyGPSTrackers();
        }

        // Métodos
        public List<(
            Bolsin bolsin,
            int numeroBolsin,
            (double latitud, double longitud) ubicacion,
            DateTime fechaHoraUbicacion
        )> obtenerLocalizacionBolsines(
            List<(
                Bolsin bolsin,
                int numero
            )> bolsinesEnviados,
            string codigoCMOrigen
        )
        {
            this.adaptadorGPS = new AdaptadorXTR4500L(
                this.apiKeyGPSTrackers[0],
                bolsinesEnviados,
                codigoCMOrigen
            );
            this.localizacionesAdaptadas = this.adaptadorGPS.recibirLocalizaciones();

            return this.localizacionesAdaptadas;
        }
    }
}
