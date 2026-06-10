using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorPrestaciones;

namespace GestorPrestacionesWeb.Pages.Trabajos
{
    public class IndexModel : PageModel
    {
        private readonly ServiciosCliente _serviciosCliente;
        private readonly ServiciosTrabajo _serviciosTrabajo;

        public List<Trabajo> Trabajos { get; set; }

        public IndexModel(ServiciosTrabajo serviciosTrabajo, ServiciosCliente serviciosCliente)
        {
            _serviciosTrabajo = serviciosTrabajo;
            _serviciosCliente = serviciosCliente;
        }

        public async Task OnGetAsync()
        {
            Trabajos = await _serviciosTrabajo.ListaTrabajos();
        }
    }
}
