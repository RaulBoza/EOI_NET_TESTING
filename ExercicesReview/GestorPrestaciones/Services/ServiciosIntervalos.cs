using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorPrestaciones
{
    public class ServiciosIntervalos
    {
        private readonly GestorContext _context = new GestorContext();

        //CRUD

        //CREATE
        public async Task<IntervaloTrabajo> CrearIntervaloTrabajo(IntervaloTrabajo intervalo)
        {
            GestorContext _context = new GestorContext();
            _context.IntervalosTrabajo.Add(intervalo);
            await _context.SaveChangesAsync();
            return intervalo;
        }
        public async Task<IntervaloBaja> CrearIntervaloBaja(IntervaloBaja intervalo)
        {
            GestorContext _context = new GestorContext();
            _context.IntervalosBaja.Add(intervalo);
            await _context.SaveChangesAsync();
            return intervalo;
        }

        //READ
        public async Task<List<IntervaloTrabajo>> ListaIntervalosTrabajo()
        {
            List<IntervaloTrabajo> intervalos = await _context.IntervalosTrabajo.ToListAsync();
            return intervalos;
        }

        public async Task<List<IntervaloBaja>> ListaIntervalosBaja()
        {
            List<IntervaloBaja> intervalos = await _context.IntervalosBaja.ToListAsync();
            return intervalos;
        }

        public async Task<List<IntervaloTrabajo>> ListaTrabajosCliente(Cliente cliente)
        {
            List<IntervaloTrabajo> intervalos = await _context.IntervalosTrabajo
                .Where(i => i.ClienteId == cliente.Id)
                .ToListAsync();
            return intervalos;
        }

        public async Task<List<IntervaloBaja>> ListaBajasCliente(Cliente cliente)
        {
            List<IntervaloBaja> intervalos = await _context.IntervalosBaja
                .Where(i => i.ClienteId == cliente.Id)
                .ToListAsync();
            return intervalos;
        }


        //UPDATE

        public async Task EditarIntervaloTrabajo(IntervaloTrabajo intervalo)
        {
            _context.IntervalosTrabajo.Update(intervalo);
            await _context.SaveChangesAsync();
        }

        public async Task EditarIntervaloBaja(IntervaloBaja intervalo)
        {
            _context.IntervalosBaja.Update(intervalo);
            await _context.SaveChangesAsync();
        }

        //DELETE

        public async Task EliminarIntervaloTrabajo(IntervaloTrabajo intervalo)
        {
            _context.IntervalosTrabajo.Remove(intervalo);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarIntervaloBaja(IntervaloBaja intervalo)
        {
            _context.IntervalosBaja.Remove(intervalo);
            await _context.SaveChangesAsync();
        }
    }
}
