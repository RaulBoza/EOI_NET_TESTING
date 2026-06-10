using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPrestaciones
{
    public class PrestacionCuidadoMenor
    {
        public enum Tipos
        {
            Contributiva,
            NoContributiva
        }
        public Tipos TipoJubilacion { get; set; }

        public async Task<int> CalcularPrestacion(Cliente cliente)
        {
            int edad = DateTime.Today.Year - cliente.FechaNacimiento.Year;


            if (cliente.FechaNacimiento.Year > DateTime.Today.AddYears(-edad).Year) edad--;

            if (edad < 21)
            {
                return 0;
            }
            else if (edad>=21 && edad<26)
            {
                return 1000;
            }
            else if (edad >= 26)
            {
                return 1500;
            }

            return 0;
        }
    }
}
