namespace Bolsines.Entidades
{
    public class Usuario
    {
        // Atributos
        private string nombre;
        private DateTime fechaAlta;
        private string contrasena;

        // Constructor
        public Usuario(string nombre, DateTime fechaAlta, string contrasena)
        {
            this.nombre = nombre;
            this.fechaAlta = fechaAlta;
            this.contrasena = contrasena;
        }
    }
}
