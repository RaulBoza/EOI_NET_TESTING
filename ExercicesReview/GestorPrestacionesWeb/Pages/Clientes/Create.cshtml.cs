using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorPrestaciones;

namespace GestorPrestacionesWeb.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ServiciosCliente _servicios;
        private readonly ServiciosTrabajo _serviciosTrabajo;
        private readonly ServiciosIntervalos _serviciosIntervalos;

        [BindProperty]
        public Cliente Cliente { get; set; }

        public List<Trabajo> TrabajoOptions { get; set; }

        public CreateModel(ServiciosCliente servicios, ServiciosTrabajo serviciosTrabajo)
        {
            _servicios = servicios;
            _serviciosTrabajo = serviciosTrabajo;
        }

        public async Task OnGetAsync()
        {
            Cliente = new Cliente();
            TrabajoOptions = await _serviciosTrabajo.ListaTrabajos();
        }

        
    }
}
