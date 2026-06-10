using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorPrestaciones
{
    public class ServiciosCliente
    {
        private readonly GestorContext _context = new GestorContext();

        //CRUD

        //CREATE
        public async Task CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }        

        //READ
        public async Task<List<Cliente>> ListaClientes()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }
        internal async Task<Cliente> BuscarCliente(Cliente cliente)
        {
            try
            {
                Cliente clienteEncontrado = await _context.Clientes.FirstOrDefaultAsync(c => c.Equals(cliente));
                return clienteEncontrado;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el cliente: {ex.Message}");
                return null;
            }
        }
        internal async Task<Cliente> BuscarCliente(string dni)
        {
            try
            {
                Cliente clienteEncontrado = await _context.Clientes.FirstOrDefaultAsync(c => c.DNI == dni);
                return clienteEncontrado;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el cliente: {ex.Message}");
                return null;
            }
        }

        //UPDATE
        public async Task EditarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        //DELETE
        public async Task EliminarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

    }
}
