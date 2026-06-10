using GestorPrestaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestorPrestacionesWeb.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ServiciosCliente _servicios;
        [BindProperty]
        public string? SearchTerm { get; set; }
        public List<Cliente> Clientes { get; set; }

        public IndexModel(ServiciosCliente servicios)
        {
            _servicios = servicios;
        }

        public async Task OnGetAsync()
        {
            Clientes = await _servicios.ListaClientes();
        }

        public async Task OnPostAsync()
        {
            var servicio = new ServiciosCliente();
            var todos = await servicio.ListaClientes();

            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                Clientes = todos;
                return;
            }

            var term = SearchTerm.Trim();
            Clientes = todos.Where(c =>
                (!string.IsNullOrEmpty(c.Nombre) && c.Nombre.Contains(term, System.StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(c.Apellidos) && c.Apellidos.Contains(term, System.StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(c.DNI) && c.DNI.Contains(term, System.StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }
    }
}
