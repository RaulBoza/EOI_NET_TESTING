using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestorPrestaciones
{
    public class IntervaloBaja
    {
        public enum TipoBaja
        {
            uno,
            dos
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public Cliente Cliente { get; set; } = null!;
        public TipoBaja Tipo { get; set; }
        public DateOnly Inicio { get; set; } = new DateOnly();
        public DateOnly Fin { get; set; } = new DateOnly();

        public override string ToString()
        {
            return $"Tipo: {Tipo} - Cliente: {ClienteId} - {Inicio} to {Fin}";
        }
    }
}
