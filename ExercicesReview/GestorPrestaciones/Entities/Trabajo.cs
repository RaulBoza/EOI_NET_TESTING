using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPrestaciones
{
    public class Trabajo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool EsDeRiesgo { get; set; } = false;
        public ICollection<IntervaloTrabajo> IntervalosTrabajo { get; set; } = new List<IntervaloTrabajo>();

        public override string ToString()
        {
            return $"{Nombre} - {Descripcion}" + (EsDeRiesgo ? " (De riesgo)" : "");
        }

        public override bool Equals(object? obj)
        {
            return obj is Trabajo trabajo &&
                   Id == trabajo.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
