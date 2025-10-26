using Microsoft.AspNetCore.Mvc;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;

namespace SC701C1.UI.Controllers
{
    public class CitaController : Controller
    {
        private readonly IListarCitaLN _listarCitaLN;

        public CitaController(IListarCitaLN listarCitaLN)
        {
            _listarCitaLN = listarCitaLN;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCitas()
        {
            var citas = await _listarCitaLN.Listar();
            return Json(citas);
        }
    }
}
