using GestorPrestaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace GestorPrestaciones
{
    public class Program
    {
        static ServiciosCliente serviciosCliente = new ServiciosCliente();
        static ServiciosTrabajo serviciosTrabajo = new ServiciosTrabajo();
        static ServiciosIntervalos serviciosIntervalo = new ServiciosIntervalos();
        static ServiciosPrestacion serviciosPrestacion = new ServiciosPrestacion();
        static PrestacionCuidadoMenor prestacionCuidadoMenor = new PrestacionCuidadoMenor();
        static async Task Main(string[] args)
        {
            //await Listas();

            //await CrearIntervaloTrabajo();
            //await CrearIntervaloBaja();
            //Console.WriteLine(await serviciosCliente.BuscarCliente("12345678A"));
            //await TrabajosYBajasCliente(await serviciosCliente.BuscarCliente("12345678A"));
            //await BorrarCliente(await serviciosCliente.BuscarCliente("12345678A"));

            //await CalcularPrestacionCuidadoMenor(await serviciosCliente.BuscarCliente("12345678A"));

            //await Listas();
        }

        //Listas

        static async Task Listas()
        {
            Console.WriteLine("Lista de Clientes");
            List<Cliente> clientes = await serviciosCliente.ListaClientes();
            clientes.ForEach(cliente => Console.WriteLine($"- {cliente.ToString()}"));
            
            Console.WriteLine("");
            Console.WriteLine("Lista de Trabajos");
            List<Trabajo> trabajos = await serviciosTrabajo.ListaTrabajos();
            trabajos.ForEach(trabajo => Console.WriteLine($"- {trabajo.ToString()}"));

            Console.WriteLine("");
            Console.WriteLine("Lista de Prestaciones");
            List<string> prestaciones = await serviciosPrestacion.ListaPrestaciones();
            prestaciones.ForEach(prestacion => Console.WriteLine($"- {prestacion}"));

            Console.WriteLine("");
            Console.WriteLine("Lista de Intervalos de Trabajo");
            List<IntervaloTrabajo> intervalosTrabajo = await serviciosIntervalo.ListaIntervalosTrabajo();
            intervalosTrabajo.ForEach(intervalo => Console.WriteLine($"- {intervalo.ToString()}"));

            Console.WriteLine("");
            Console.WriteLine("Lista de Intervalos de Baja");
            List<IntervaloBaja> intervalosBaja = await serviciosIntervalo.ListaIntervalosBaja();
            intervalosBaja.ForEach(intervalo => Console.WriteLine($"- {intervalo.ToString()}"));

        }

        //crear un intervalo de trabajo
        public static async Task CrearIntervaloTrabajo()
        {
            Console.WriteLine("Intervalo de Trabajo Creado");
            var trabajo = await serviciosTrabajo.BuscarTrabajo("Minero");
            var cliente = await serviciosCliente.BuscarCliente("12345678A");
            var intervaloTrabajo = await serviciosIntervalo.CrearIntervaloTrabajo(
                new IntervaloTrabajo
                {
                    TrabajoId = trabajo.Id,
                    ClienteId = cliente.Id,
                    Inicio = new DateOnly(2000, 1, 1),
                    Fin = new DateOnly(2010, 1, 1)
                }
            );
        }

        // crear una baja
        public static async Task CrearIntervaloBaja()
        {
            Console.WriteLine("Intervalo de Baja Creado");
            var cliente = await serviciosCliente.BuscarCliente("12345678A");
            var baja = await serviciosIntervalo.CrearIntervaloBaja(
                new IntervaloBaja
                {
                    ClienteId = cliente.Id,
                    Tipo = IntervaloBaja.TipoBaja.uno,
                    Inicio = new DateOnly(2009, 1, 1),
                    Fin = new DateOnly(2010, 1, 1)
                }
            );
        }

        // trabajos y bajas de cliente
        public static async Task<Cliente> TrabajosYBajasCliente(Cliente cliente)
        {
            Console.WriteLine("Lista de Trabajos y Bajas del Cliente");
            List<IntervaloTrabajo> trabajos = await serviciosIntervalo.ListaTrabajosCliente(cliente);
            List<IntervaloBaja> bajas = await serviciosIntervalo.ListaBajasCliente(cliente);
            // Process the lists as needed
            Console.WriteLine($"Trabajos y bajas de {cliente.Nombre}:");
            trabajos.ForEach(trabajo => Console.WriteLine($"Trabajo: {serviciosTrabajo.NombreTrabajoPorId(trabajo.TrabajoId).Result} - {trabajo.Inicio} to {trabajo.Fin}"));
            bajas.ForEach(baja => Console.WriteLine($"Baja: {baja.Inicio} to {baja.Fin}"));
            return cliente;
        }
        //borrar cliente
        public static async Task BorrarCliente(Cliente cliente)
        {
            Console.WriteLine("Borrando cliente...");
            await serviciosCliente.EliminarCliente(cliente);
            if (serviciosCliente.BuscarCliente(cliente) == null)
            {
                Console.WriteLine($"Cliente eliminado.");
            }
        }

        // calcular prestación cuidado menor
        public static async Task CalcularPrestacionCuidadoMenor(Cliente cliente)
        {
            Console.WriteLine("Calculando prestación por cuidado de menor...");
            var prestacion = await prestacionCuidadoMenor.CalcularPrestacion(cliente);
            Console.WriteLine($"La prestación por cuidado de menor para {cliente.Nombre} es: {prestacion}");
        }


    }
}
