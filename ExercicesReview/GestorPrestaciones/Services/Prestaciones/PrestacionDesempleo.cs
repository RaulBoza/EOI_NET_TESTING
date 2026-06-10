using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPrestaciones
{
    public class PrestacionDesempleo
    {
        public enum TiposDespido
        {
            Procedente,
            Abandono,
            Dimision
        }

        public TiposDespido TipoDespido { get; set; }
    }
}
