namespace Bolsines.Entidades
{
    public class Bolsin
    {
        // Atributos
        private DateTime fecha;
        private int numeroBolsin;
        private int numeroPrecinto;
        private double peso;
        private ComisionMedica origen;
        private ComisionMedica destino;
        private List<CambioEstadoBolsin> cambiosEstado;

        // Constructor
        public Bolsin(
            DateTime fecha,
            int numeroBolsin,
            int numeroPrecinto,
            double peso,
            ComisionMedica origen,
            ComisionMedica destino,
            List<CambioEstadoBolsin> cambiosEstado
        )
        {
            this.fecha = fecha;
            this.numeroBolsin = numeroBolsin;
            this.numeroPrecinto = numeroPrecinto;
            this.peso = peso;
            this.origen = origen;
            this.destino = destino;
            this.cambiosEstado = cambiosEstado;
        }

        // Métodos
        public bool esTuCMOrigen(ComisionMedica cm)
        {
            return cm == this.origen;
        }

        public bool sosEnviado()
        {
            foreach (CambioEstadoBolsin cambioEstado in this.cambiosEstado)
            {
                if (cambioEstado.sosActual())
                {
                    return cambioEstado.sosEnviado();
                }
            }
            return false;
        }

        public int getNumeroBolsin()
        {
            return this.numeroBolsin;
        }

        public ComisionMedica obtenerCMDestino()
        {
            return this.destino;
        }
    }
}
