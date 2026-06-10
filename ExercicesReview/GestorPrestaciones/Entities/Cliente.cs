using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestorPrestaciones
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public string DNI { get; set; } = string.Empty;
        public string Sexo { get; set;} = string.Empty;
        public int BaseReguladora { get; set; } = 0;
        public int GradoDiscapacidad { get; set; } = 0;
        public List<IntervaloTrabajo> Trabajos { get; set; } = new List<IntervaloTrabajo>();
        public List<IntervaloBaja> BajasLaborales { get; set; } = new List<IntervaloBaja>();

        public override string ToString()
        {
            return $"{Nombre} {Apellidos} (DNI: {DNI}, Fecha de Nacimiento: {FechaNacimiento}, Sexo: {Sexo})";
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


    }
}
