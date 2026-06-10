using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Text;

namespace GestorPrestaciones
{
    public class GestorContext:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<IntervaloTrabajo> IntervalosTrabajo { get; set; }
        public DbSet<IntervaloBaja> IntervalosBaja { get; set; }
        public DbSet<Prestacion> Prestaciones { get; set; }

        public GestorContext()
        {
        }

        public GestorContext(DbContextOptions<GestorContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\rakim\Documents\GitHub\EOI_NET_TESTING\ExercicesReview\GestorPrestaciones\gestorprestaciones.db");    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Cliente cliente1 = new Cliente
            {
                Id = 1,
                Nombre = "Juan",
                Apellidos = "Pérez",
                FechaNacimiento = new DateOnly(1980, 5, 15),
                DNI = "12345678A",
                Sexo = "Masculino"
            };

            modelBuilder.Entity<Cliente>().HasData(cliente1,
                new Cliente
                {
                    Id = 2,
                    Nombre = "María",
                    Apellidos = "García",
                    FechaNacimiento = new DateOnly(1990, 8, 20),
                    DNI = "87654321B",
                    Sexo = "Femenino"
                }
            );

            Trabajo trabajo1 = new Trabajo { Id = 1, Nombre = "Minero", Descripcion = "Trabajo en minas subterráneas", EsDeRiesgo = true };

            modelBuilder.Entity<Trabajo>().HasData( trabajo1,
                new Trabajo { Id = 2, Nombre = "Cajero", Descripcion = "Trabajo en caja de supermercado", EsDeRiesgo = false }
            );

            modelBuilder.Entity<Trabajo>()
                .HasMany(t => t.IntervalosTrabajo)
                .WithOne(it => it.Trabajo)
                .HasForeignKey(t => t.TrabajoId)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Trabajos)
                .WithOne(it => it.Cliente)
                .HasForeignKey(it => it.ClienteId)
                .IsRequired();

            //modelBuilder.Entity<IntervaloTrabajo>().HasData(
            //    new IntervaloTrabajo { Id = 1, TrabajoId = trabajo1.Id, ClienteId = cliente1.Id, Inicio = new DateOnly(2000, 1, 1), Fin = new DateOnly(2010, 1, 1) }
            //);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.BajasLaborales)
                .WithOne(it => it.Cliente)
                .HasForeignKey(it => it.ClienteId)
                .IsRequired();

            //modelBuilder.Entity<IntervaloBaja>().HasData(
            //    new IntervaloBaja { Id = 1, ClienteId = cliente1.Id, Tipo = IntervaloBaja.TipoBaja.uno, Inicio = new DateOnly(2000, 1, 1), Fin = new DateOnly(2010, 1, 1) }
            //);
        }

    }
}
