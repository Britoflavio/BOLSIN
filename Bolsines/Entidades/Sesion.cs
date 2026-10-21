namespace Bolsines.Entidades
{
    public class Sesion
    {
        // Atributos
        private DateTime? fechaHoraFin;
        private DateTime fechaHoraInicio;
        private Usuario usuario;

        // Constructor
        public Sesion(DateTime fechaHoraInicio, DateTime? fechaHoraFin, Usuario usuario)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.usuario = usuario;
        }

        // Métodos
        public Usuario getUsuario()
        {
            return usuario;
        }
    }
}
