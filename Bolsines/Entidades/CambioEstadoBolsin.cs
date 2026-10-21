using System.Security.Cryptography.X509Certificates;

namespace Bolsines.Entidades
{
    public class CambioEstadoBolsin
    {
        // Atributos
        private DateTime fechaHoraInicio;
        private DateTime? fechaHoraFin;
        private Estado estado;

        // Constructor
        public CambioEstadoBolsin(DateTime fechaHoraInicio, DateTime? fechaHoraFin, Estado estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.estado = estado;
        }

        // Métodos
        public bool sosActual()
        {
            return this.fechaHoraFin == null;
        }

        public bool sosEnviado()
        {
            return this.estado.esEnviado();
        }
    }
}
