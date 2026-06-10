using GestorPrestaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestorPrestacionesWeb.Pages.Clientes
{
    public class DetallesClienteModel : PageModel
    {
        private readonly ServiciosCliente _servicios;
        public Cliente? Cliente { get; set; }

        public DetallesClienteModel(ServiciosCliente servicios)
        {
            _servicios = servicios;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var todos = await _servicios.ListaClientes();
            Cliente = todos.FirstOrDefault(c => c.Id == id);
            if (Cliente == null) return NotFound();
            return Page();
        }
    }
}
