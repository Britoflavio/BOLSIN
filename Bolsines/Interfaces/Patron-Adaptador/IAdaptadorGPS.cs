using Bolsines.Entidades;

namespace Bolsines.Interfaces.Patron_Adaptador
{
    public interface IAdaptadorGPS
    {
        public List<(
            Bolsin bolsin,
            int numeroBolsin,
            (double latitud, double longitud) ubicacion,
            DateTime fechaHoraUbicacion
        )> recibirLocalizaciones();

        public void solicitarLocalizaciones();

        public void adaptarLocalizaciones();
    }
}
