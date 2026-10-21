namespace Bolsines.Entidades
{
    public class Empleado
    {
        // Atributos
        private string apellido;
        private string email;
        private string nombre;
        private Usuario usuario;
        private Rol rol;
        private ComisionMedica asignadoA;

        // Constructor
        public Empleado(
            string apellido,
            string email,
            string nombre,
            Usuario usuario,
            Rol rol,
            ComisionMedica comisionMedica
        )
        {
            this.apellido = apellido;
            this.email = email;
            this.nombre = nombre;
            this.usuario = usuario;
            this.rol = rol;
            this.asignadoA = comisionMedica;
        }

        // Métodos
        public bool esTuUsuario(Usuario usuario)
        {
            return this.usuario == usuario;
        }

        public (ComisionMedica cm, string nombre, string codigo) mostrarCM()
        {
            ComisionMedica cm = asignadoA;
            string nombre = asignadoA.getNombre();
            string codigo = asignadoA.getCodigo();

            return (cm, nombre, codigo);
        }

        public bool esTuCM(ComisionMedica cm)
        {
            return this.asignadoA == cm;
        }

        public bool sosGCM()
        {
            return this.rol.esGCM();
        }

        public string getEmail()
        {
            return this.email;
        }

        // Para el saludo en el menú principal
        public string getNombre()
        {
            return this.nombre;
        }
    }
}
