using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPrestaciones
{
    
    public class PrestacionJubilacion
    {
        public enum Tipos
        {
            Contributiva,
            NoContributiva
        }
        public Tipos TipoJubilacion { get; set; }

    }
}
