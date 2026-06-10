using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPrestaciones
{
    public class Prestacion
    {
        public enum TipoPrestacion
        {
            CuidadoMenor,
            Desempleo,
            IncapacidadLaboral,
            Jubilacion
        }
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public TipoPrestacion Tipo { get; set; }
        public double TotalPerestacion { get; set; }

        public override string ToString()
        {
            return $"Prestacion por {Tipo} para {Cliente.Nombre} - Total: {TotalPerestacion}€";
        }

        public override bool Equals(object? obj)
        {
            return obj is Prestacion prestacion &&
                   Tipo == prestacion.Tipo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Tipo);
        }
    }
}
