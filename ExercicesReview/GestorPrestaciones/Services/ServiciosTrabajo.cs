using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorPrestaciones
{
    public class ServiciosTrabajo
    {
        private readonly GestorContext _context = new GestorContext();

        //CRUD

        //CREATE
        public async Task CrearTrabajo(Trabajo trabajo)
        {
            _context.Trabajos.Add(trabajo);
            await _context.SaveChangesAsync();
        }

        //READ
        public async Task<List<Trabajo>> ListaTrabajos()
        {
            return await _context.Trabajos.ToListAsync(); ;
        }

        public async Task<Trabajo> BuscarTrabajo(int id)
        {
            try
            {
                Trabajo trabajo = await _context.Trabajos.FirstOrDefaultAsync(t => t.Id == id);
                return trabajo;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el trabajo: {ex.Message}");
                return null;
            }
        }

        public async Task<Trabajo> BuscarTrabajo(string nombre)
        {
            try
            {
                Trabajo trabajo = await _context.Trabajos.FirstOrDefaultAsync(t => t.Nombre == nombre);
                return trabajo;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el trabajo: {ex.Message}");
                return null;
            }

        }

        public async Task<string> NombreTrabajoPorId(int id)   
        {
            try
            {
                Trabajo trabajo = await _context.Trabajos.FirstOrDefaultAsync(t => t.Id == id);
                return trabajo.Nombre;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el trabajo: {ex.Message}");
                return null;
            }
        }

        //UPDATE
        public async Task EditarTrabajo(Trabajo trabajo)
        {
            _context.Trabajos.Update(trabajo);
            await _context.SaveChangesAsync();
        }

        //DELETE
        public async Task EliminarTrabajo(Trabajo trabajo)
        {
            _context.Trabajos.Remove(trabajo);
            await _context.SaveChangesAsync();
        }
    }
}
