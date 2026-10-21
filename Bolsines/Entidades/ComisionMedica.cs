namespace Bolsines.Entidades
{
    public class ComisionMedica
    {
        // Atributos
        private string codigo;
        private string direccion;
        private string email;
        private string nombre;
        private string telefono;

        // Constructor
        public ComisionMedica(
            string codigo,
            string direccion,
            string email,
            string nombre,
            string telefono
        )
        {
            this.codigo = codigo;
            this.direccion = direccion;
            this.email = email;
            this.nombre = nombre;
            this.telefono = telefono;
        }

        // Métodos
        public string getNombre()
        {
            return nombre;
        }

        public string getCodigo()
        {
            return codigo;
        }
    }
}
