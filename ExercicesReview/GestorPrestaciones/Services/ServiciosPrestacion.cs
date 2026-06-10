using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorPrestaciones
{
    public class ServiciosPrestacion
    {
        private readonly GestorContext _context = new GestorContext();

        //CRUD

        //CREATE
        public async Task CrearPrestacion(Prestacion prestacion)
        {
            _context.Prestaciones.Add(prestacion);
            await _context.SaveChangesAsync();
        }

        //READ
        public async Task<List<string>> ListaPrestaciones()
        {
            List<string> prestaciones = Prestacion.TipoPrestacion.GetNames(typeof(Prestacion.TipoPrestacion)).ToList();
            return await Task.FromResult(prestaciones);
        }

        //UPDATE
        public async Task EditarPrestacion(Prestacion prestacion)
        {
            _context.Prestaciones.Update(prestacion);
            await _context.SaveChangesAsync();
        }

        //DELETE
        public async Task EliminarPrestacion(Prestacion prestacion)
        {
            _context.Prestaciones.Remove(prestacion);
            await _context.SaveChangesAsync();
        }
    }
}
