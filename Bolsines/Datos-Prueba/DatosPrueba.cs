using Bolsines.Entidades;
using Bolsines.Interfaces.Dispositivos;
using Bolsines.Interfaces.Sistemas_Externos;

namespace Bolsines.Datos_Prueba
{
    public class DatosPrueba
    {
        // Objetos :Estado
        public static readonly Estado Estado1 = new Estado("BOLSIN", "Descripcion1", "CREADO");

        public static readonly Estado Estado2 = new Estado("BOLSIN", "Descripcion2", "CERRADO");

        public static readonly Estado Estado3 = new Estado("BOLSIN", "Descripcion3", "ENVIADO");

        public static readonly Estado Estado4 = new Estado(
            "BOLSIN",
            "Descripcion4",
            "RECIBIDO_EN_CM_DESTINO"
        );

        public static readonly Estado Estado5 = new Estado("BOLSIN", "Descripcion5", "DE_BAJA");

        // Objetos :CambioEstadoBolsin
        public static readonly CambioEstadoBolsin CambioEstadoBolsin11 = new CambioEstadoBolsin(
            new DateTime(2026, 2, 12, 9, 15, 23),
            new DateTime(2026, 4, 8, 14, 30, 41),
            Estado1
        );

        public static readonly CambioEstadoBolsin CambioEstadoBolsin12 = new CambioEstadoBolsin(
            new DateTime(2026, 4, 8, 14, 30, 41),
            new DateTime(2026, 11, 21, 11, 45, 8),
            Estado2
        );

        public static readonly CambioEstadoBolsin CambioEstadoBolsin13 = new CambioEstadoBolsin(
            new DateTime(2026, 11, 21, 11, 45, 8),
            null,
            Estado3
        );

        public static readonly List<CambioEstadoBolsin> CambiosEstadoBolsin1 =
            new List<CambioEstadoBolsin>
            {
                CambioEstadoBolsin11,
                CambioEstadoBolsin12,
                CambioEstadoBolsin13,
            };

        public static readonly CambioEstadoBolsin CambioEstadoBolsin21 = new CambioEstadoBolsin(
            new DateTime(2026, 5, 30, 8, 20, 57),
            null,
            Estado1
        );

        public static readonly List<CambioEstadoBolsin> CambiosEstadoBolsin2 =
            new List<CambioEstadoBolsin> { CambioEstadoBolsin21 };

        public static readonly CambioEstadoBolsin CambioEstadoBolsin31 = new CambioEstadoBolsin(
            new DateTime(2026, 9, 17, 10, 5, 12),
            new DateTime(2026, 10, 5, 16, 10, 49),
            Estado1
        );

        public static readonly CambioEstadoBolsin CambioEstadoBolsin32 = new CambioEstadoBolsin(
            new DateTime(2026, 10, 5, 16, 10, 49),
            null,
            Estado2
        );

        public static readonly List<CambioEstadoBolsin> CambiosEstadoBolsin3 =
            new List<CambioEstadoBolsin> { CambioEstadoBolsin31, CambioEstadoBolsin32 };

        public static readonly CambioEstadoBolsin CambioEstadoBolsin41 = new CambioEstadoBolsin(
            new DateTime(2026, 9, 21, 9, 14, 23),
            new DateTime(2026, 10, 8, 16, 42, 17),
            Estado1
        );

        public static readonly CambioEstadoBolsin CambioEstadoBolsin42 = new CambioEstadoBolsin(
            new DateTime(2026, 10, 8, 16, 42, 17),
            new DateTime(2026, 11, 19, 11, 8, 34),
            Estado2
        );

        public static readonly CambioEstadoBolsin CambioEstadoBolsin43 = new CambioEstadoBolsin(
            new DateTime(2026, 11, 19, 11, 8, 34),
            null,
            Estado3
        );

        public static readonly List<CambioEstadoBolsin> CambiosEstadoBolsin4 =
            new List<CambioEstadoBolsin>
            {
                CambioEstadoBolsin41,
                CambioEstadoBolsin42,
                CambioEstadoBolsin43,
            };

        // Objetos :ComisionMedica
        public static readonly ComisionMedica ComisionMedica1 = new ComisionMedica(
            "C1091AAH",
            "Moreno 401",
            "sedecentral@srt.gob.ar",
            "Comisión Médica CABA - Sede Central",
            "0800-666-6778"
        );

        public static readonly ComisionMedica ComisionMedica2 = new ComisionMedica(
            "C1430BQV",
            "Av. Olazábal 4300",
            "villaurquiza@srt.gob.ar",
            "Comisión Médica CABA — Villa Urquiza",
            "0800-666-6779"
        );

        public static readonly ComisionMedica ComisionMedica3 = new ComisionMedica(
            "B1804CPF",
            "Arribeños 256",
            "ezeiza@srt.gob.ar",
            "Comisión Médica Ezeiza",
            "0800-666-6780"
        );

        public static readonly ComisionMedica ComisionMedica4 = new ComisionMedica(
            "B1826DQD",
            "Hipólito Yrigoyen 5645",
            "lanus@srt.gob.ar",
            "Comisión Médica Lanús",
            "0800-666-6781"
        );

        // Objetos :Bolsin
        public static readonly Bolsin Bolsin1 = new Bolsin(
            new DateTime(2026, 2, 12),
            1,
            1437,
            427.35,
            ComisionMedica1,
            ComisionMedica3,
            CambiosEstadoBolsin1
        );

        public static readonly Bolsin Bolsin2 = new Bolsin(
            new DateTime(2026, 5, 30),
            2,
            5284,
            918.72,
            ComisionMedica3,
            ComisionMedica2,
            CambiosEstadoBolsin2
        );

        public static readonly Bolsin Bolsin3 = new Bolsin(
            new DateTime(2026, 9, 17),
            3,
            8916,
            1364.18,
            ComisionMedica2,
            ComisionMedica4,
            CambiosEstadoBolsin3
        );

        public static readonly Bolsin Bolsin4 = new Bolsin(
            new DateTime(2026, 9, 21),
            4,
            8916,
            1364.18,
            ComisionMedica1,
            ComisionMedica4,
            CambiosEstadoBolsin4
        );

        // Objetos :Usuario
        public static readonly Usuario Usuario1 = new Usuario(
            "marcela.cattaneo",
            new DateTime(2022, 3, 14),
            "Bolsin404NoEncontrado"
        );

        public static readonly Usuario Usuario2 = new Usuario(
            "german.velez",
            new DateTime(2023, 6, 5),
            "Comision66SinPapeles"
        );

        public static readonly Usuario Usuario3 = new Usuario(
            "salvador.barbera",
            new DateTime(2023, 10, 21),
            "PDF999Paginas"
        );

        public static readonly Usuario Usuario4 = new Usuario(
            "federico.mizzau",
            new DateTime(2024, 2, 15),
            "Comision24x7"
        );

        public static readonly Usuario Usuario5 = new Usuario(
            "joaquin.bonugli",
            new DateTime(2024, 8, 14),
            "FolioVaFolioViene"
        );

        // Objeto :Sesion
        public static readonly Sesion SesionActual = new Sesion(DateTime.Now, null, Usuario1);

        // Objetos :Rol
        public static readonly Rol Rol1 = new Rol("Descripcion1", "ENCARGADO_DE_BOLSINES");

        public static readonly Rol Rol2 = new Rol("Descripcion2", "ENCARGADO_DE_DOCUMENTACION");

        public static readonly Rol Rol3 = new Rol("Descripcion3", "GERENTE_DE_COMISION_MEDICA");

        public static readonly Rol Rol4 = new Rol("Descripcion4", "PARAMETRIZADOR_DEL_SISTEMA");

        // Objetos :Empleado
        public static readonly Empleado Empleado1 = new Empleado(
            "Cattaneo",
            "mfcattaneo@gmail.com",
            "Marcela",
            Usuario1,
            Rol1,
            ComisionMedica1
        );

        public static readonly Empleado Empleado2 = new Empleado(
            "Vélez",
            "germanevelez@hotmail.com",
            "Germán",
            Usuario2,
            Rol2,
            ComisionMedica1
        );

        public static readonly Empleado Empleado3 = new Empleado(
            "Barbera",
            "jsbarbera4@gmail.com",
            "Salvador",
            Usuario3,
            Rol3,
            ComisionMedica3
        );

        public static readonly Empleado Empleado4 = new Empleado(
            "Mizzau",
            "federicomizzau.77@gmail.com",
            "Federico",
            Usuario4,
            Rol4,
            ComisionMedica4
        );

        public static readonly Empleado Empleado5 = new Empleado(
            "Bonugli",
            "joaquin.bonugli@gmail.com",
            "Joaquín",
            Usuario5,
            Rol3,
            ComisionMedica4
        );

        // Objetos que conoce el controlador mediante relaciones de dependencia
        public static List<Bolsin> cargarBolsines()
        {
            List<Bolsin> listaBolsines = new List<Bolsin>();
            listaBolsines.Add(Bolsin1);
            listaBolsines.Add(Bolsin2);
            listaBolsines.Add(Bolsin3);
            listaBolsines.Add(Bolsin4);
            return listaBolsines;
        }

        public static List<Empleado> cargarEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            listaEmpleados.Add(Empleado1);
            listaEmpleados.Add(Empleado2);
            listaEmpleados.Add(Empleado3);
            listaEmpleados.Add(Empleado4);
            listaEmpleados.Add(Empleado5);
            return listaEmpleados;
        }

        public static Sesion cargarSesionActual()
        {
            return SesionActual;
        }

        // API Keys de los GPS
        public static List<string> getAPIKeyGPSTrackers()
        {
            List<string> apiKeyGPSTrackers = new List<string>();
            apiKeyGPSTrackers.Add("GPST_XTR4500L_8F7D-29AC-41E9-B6A2-7F9DCC53E10A");
            apiKeyGPSTrackers.Add("GPST_QX7A_B194-CF82-6A3E-91D4-54B8A0F7E2C9");
            apiKeyGPSTrackers.Add("GPST_MTR900_DA91-74F0-CE62-8B15-93E4AB7D1F56");
            return apiKeyGPSTrackers;
        }

        // Objetos :GPSXTR4500L
        public static readonly GPSXTR4500L gpsXTR4500L1 = new GPSXTR4500L(1);

        public static readonly GPSXTR4500L gpsXTR4500L2 = new GPSXTR4500L(4);

        // Objetos GPS que conocen los adaptadores que les corresponde
        public static List<GPSXTR4500L> cargarGPSsXTR4500L()
        {
            List<GPSXTR4500L> listaGPSs = new List<GPSXTR4500L>();
            listaGPSs.Add(gpsXTR4500L1);
            listaGPSs.Add(gpsXTR4500L2);
            return listaGPSs;
        }

        // API Key de Google Maps
        public static string getAPIKeyGoogleMaps()
        {
            return "AIzaSyDQV7y8a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6";
        }

        // Objeto :ServidorGoogleMaps
        public static readonly ServidorGoogleMaps servidorGoogleMaps =
            new ServidorGoogleMaps();

        public static ServidorGoogleMaps cargarServidorGoogleMaps()
        {
            return servidorGoogleMaps;
        }
    }
}
