namespace Bolsines.Entidades
{
    public class Estado
    {
        // Atributos
        private string ambito;
        private string descripcion;
        private string nombre;

        // Constructor
        public Estado(string ambito, string descripcion, string nombre)
        {
            this.ambito = ambito;
            this.descripcion = descripcion;
            this.nombre = nombre;
        }

        // Métodos
        public bool esEnviado()
        {
            return this.nombre == "ENVIADO";
        }
    }
}
