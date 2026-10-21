namespace Bolsines.Utilidades
{
    public class Localizacion
    {
        private static readonly (double latitud, double longitud)[] ContornoArgentina = new[]
        {
            (-21.8, -65.6),
            (-22.2, -62.6),
            (-26.2, -58.2),
            (-25.5, -54.0),
            (-30.0, -57.6),
            (-34.4, -58.3),
            (-39.0, -62.0),
            (-45.0, -65.5),
            (-54.8, -68.3),
            (-54.9, -66.5),
            (-52.0, -68.5),
            (-46.0, -71.5),
            (-33.0, -70.0),
            (-23.0, -67.0),
        };

        public static bool EstaEnArgentina(double latitud, double longitud)
        {
            bool estaEnArgentina = false;
            int j = ContornoArgentina.Length - 1;

            for (int i = 0; i < ContornoArgentina.Length; i++)
            {
                var pi = ContornoArgentina[i];
                var pj = ContornoArgentina[j];

                if (
                    (pi.longitud > longitud) != (pj.longitud > longitud)
                    && (
                        latitud
                        < (pj.latitud - pi.latitud)
                            * (longitud - pi.longitud)
                            / (pj.longitud - pi.longitud)
                            + pi.latitud
                    )
                )
                {
                    estaEnArgentina = !estaEnArgentina;
                }
                j = i;
            }
            return estaEnArgentina;
        }
    }
}
