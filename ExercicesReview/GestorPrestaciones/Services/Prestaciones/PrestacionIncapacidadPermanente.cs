using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPrestaciones
{     
    public class PrestacionIncapacidadPermanente
    {
        public enum TipoIncapacidades
        {
            Parcial,
            Absoluta,
            Total,
            GranInvalidez
        }
        public enum TipoContingencias
        {
            Comun,
            Preofesinal
        }
        public TipoIncapacidades Tipo { get; set; }
        public TipoContingencias TipoContingencia { get; set; }
    }
}
