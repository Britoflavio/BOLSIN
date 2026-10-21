using Bolsines.Datos_Prueba;
using Bolsines.Entidades;
using Bolsines.Interfaces;
// using Bolsines.Interfaces.Patron_Adaptador;
using Bolsines.Interfaces.Pantallas;
using Microsoft.AspNetCore.Components;

namespace Bolsines.Controlador
{
    public class ControladorSeguimiento
    {
        // Atributos de interacción
        private TaskCompletionSource<bool> senalBotonAceptar;
        private NavigationManager navigationManager;

        // Métodos de interacción
        public void ConfirmacionAceptada()
        {
            this.senalBotonAceptar?.TrySetResult(true);
        }

        // Atributos
        private Sesion sesionActual;
        private Usuario usuarioLogueado;
        private (ComisionMedica cm, string nombre, string codigo) cmUsuarioLogueado;
        private List<(Bolsin bolsin, int numero)> bolsinesEnviados = new();
        private List<(
            Bolsin bolsin,
            int numeroBolsin,
            (double latitud, double longitud) ubicacion,
            DateTime fechaHoraUbicacion
        )> localizacionBolsines;
        private (
            Bolsin bolsin,
            int numero,
            (double latitud, double longitud) ubicacion,
            DateTime fechaHoraUbicacion
        ) bolsinSeleccionado;
        private string emailGCMDestino;
        private PantallaSeguimiento pantallaSeguimiento;
        private List<Empleado> empleados;
        private List<Bolsin> bolsines;
        private InterfazGPS interfazGPS;
        private InterfazGoogleMaps interfazGoogleMaps;

        // Constructor
        public ControladorSeguimiento(
            PantallaSeguimiento pantallaSeguimiento,
            NavigationManager navigationManager
        )
        {
            this.sesionActual = DatosPrueba.cargarSesionActual();
            this.pantallaSeguimiento = pantallaSeguimiento;
            this.empleados = DatosPrueba.cargarEmpleados();
            this.bolsines = DatosPrueba.cargarBolsines();
            this.navigationManager = navigationManager;
        }

        // Métodos
        public void nuevoSeguimientoBolsines()
        {
            this.buscarCMUsuarioLogueado();
            this.obtenerBolsinesEnviados();
            this.buscarLocalizacionBolsines();
            this.mostrarLocalizacionBolsines();
            pantallaSeguimiento.pedirSeleccionBolsin(this.localizacionBolsines);
        }

        public void buscarCMUsuarioLogueado()
        {
            this.usuarioLogueado = sesionActual.getUsuario();

            foreach (Empleado empleado in this.empleados)
            {
                if (empleado.esTuUsuario(this.usuarioLogueado))
                {
                    this.cmUsuarioLogueado = empleado.mostrarCM();
                    pantallaSeguimiento.mostrarCMUsuarioLogueado(
                        this.cmUsuarioLogueado.nombre,
                        this.cmUsuarioLogueado.codigo
                    );
                    return;
                }
            }
        }

        public void obtenerBolsinesEnviados()
        {
            foreach (Bolsin bolsin in this.bolsines)
            {
                if (bolsin.esTuCMOrigen(this.cmUsuarioLogueado.cm) && bolsin.sosEnviado())
                {
                    var numeroBolsin = bolsin.getNumeroBolsin();
                    this.bolsinesEnviados.Add((bolsin, numeroBolsin));
                }
            }
        }

        public void buscarLocalizacionBolsines()
        {
            // Habría que pasarle datos que no están definidos como atributos en el controlador.
            // Preguntar si está bien aplicado el patrón Adapter de la manera que ya había hecho.
            //
            // IAdaptadorGPS adaptadorGPS = new AdaptadorXTR4500L(...);
            //
            // this.interfazGPS = new InterfazGPS(adaptadorGPS);

            this.interfazGPS = new InterfazGPS();
            this.localizacionBolsines = this.interfazGPS.obtenerLocalizacionBolsines(
                this.bolsinesEnviados,
                this.cmUsuarioLogueado.codigo
            );
        }

        public void mostrarLocalizacionBolsines()
        {
            this.interfazGoogleMaps = new InterfazGoogleMaps();
            this.interfazGoogleMaps.mostrarBolsinesEnMapa(this.localizacionBolsines);
        }

        public void tomarSeleccionBolsin(
            (
                Bolsin bolsin,
                int numero,
                (double latitud, double longitud) ubicacion,
                DateTime fechaHoraUbicacion
            ) bolsinSeleccionado
        )
        {
            this.bolsinSeleccionado = bolsinSeleccionado;
            pantallaSeguimiento.solicitarConfirmacionEnvioMail();
        }

        public async Task tomarConfirmacion()
        {
            this.obtenerCorreoGerente();
            this.llamarCU30();
            this.pantallaSeguimiento.informarEnvioMail();
            this.senalBotonAceptar = new TaskCompletionSource<bool>();

            Task usuarioAcepto = senalBotonAceptar.Task;
            Task finalizoTemporizador = Task.Delay(60000);

            await Task.WhenAny(usuarioAcepto, finalizoTemporizador);
            this.finCU();
        }

        public void obtenerCorreoGerente()
        {
            foreach (Empleado empleado in this.empleados)
            {
                if (
                    empleado.esTuCM(this.bolsinSeleccionado.bolsin.obtenerCMDestino())
                    && empleado.sosGCM()
                )
                {
                    this.emailGCMDestino = empleado.getEmail();
                    Console.WriteLine("Correo del gerente de CM destino: " + this.emailGCMDestino);
                    return;
                }
            }
        }

        public void llamarCU30()
        {
            CU_30_Notificar_Ubicacion_de_Bolsin cu30 = new CU_30_Notificar_Ubicacion_de_Bolsin();
            cu30.include(
                this.emailGCMDestino,
                this.bolsinSeleccionado.numero,
                this.bolsinSeleccionado.fechaHoraUbicacion,
                this.bolsinSeleccionado.ubicacion.latitud,
                this.bolsinSeleccionado.ubicacion.longitud
            );
            Console.WriteLine("CU 30 llamado con éxito");
        }

        public void finCU()
        {
            this.navigationManager.NavigateTo("/");
        }
    }
}
