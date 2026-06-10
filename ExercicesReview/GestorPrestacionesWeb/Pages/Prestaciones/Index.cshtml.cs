using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorPrestaciones;

namespace GestorPrestacionesWeb.Pages.Prestaciones
{
    public class IndexModel : PageModel
    {
        private readonly ServiciosPrestacion _servicios;
        public List<string> Prestaciones { get; set; }

        public IndexModel(ServiciosPrestacion servicios)
        {
            _servicios = servicios;
        }

        public async Task OnGetAsync()
        {
            Prestaciones = await _servicios.ListaPrestaciones();
        }
    }
}
