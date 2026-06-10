using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestorPrestaciones
{
    public class IntervaloTrabajo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TrabajoId { get; set; }
        [Required]
        public Trabajo Trabajo { get; set; } = null!;
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public Cliente Cliente { get; set; } = null!;

        public DateOnly Inicio { get; set; } = new DateOnly();
        public DateOnly Fin { get; set; } = new DateOnly();

        public override string ToString()
        {
            return $"IdCliente:{ClienteId} - IdTrabajo:{TrabajoId} - {Inicio} to {Fin}";
        }

        public override bool Equals(object? obj)
        {
            return obj is IntervaloTrabajo trabajo &&
                   Id == trabajo.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
