using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorPrestaciones;

namespace GestorPrestacionesWeb.Pages.Trabajos
{
    public class CreateModel : PageModel
    {
        private readonly ServiciosTrabajo _servicios;

        [BindProperty]
        public Trabajo Trabajo { get; set; }

        public CreateModel(ServiciosTrabajo servicios)
        {
            _servicios = servicios;
        }

        public void OnGet()
        {
            Trabajo = new Trabajo();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _servicios.CrearTrabajo(Trabajo);
            return RedirectToPage("Index");
        }
    }
}
