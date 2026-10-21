namespace Bolsines.Entidades
{
    public class Rol
    {
        // Atributos
        private string descripcion;
        private string nombre;

        // Constructor
        public Rol(string descripcion, string nombre)
        {
            this.descripcion = descripcion;
            this.nombre = nombre;
        }

        // Métodos
        public bool esGCM()
        {
            return nombre == "GERENTE_DE_COMISION_MEDICA";
        }
    }
}
