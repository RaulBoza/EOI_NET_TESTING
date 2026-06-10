using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GestorPrestaciones;

namespace GestorPrestacionesWeb
{
    public class IndexModel : PageModel
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        public async Task OnGetAsync()
        {
            // Cargar todos los clientes por defecto
            var servicio = new ServiciosCliente();
            Clientes = await servicio.ListaClientes();
        }

    }
}
