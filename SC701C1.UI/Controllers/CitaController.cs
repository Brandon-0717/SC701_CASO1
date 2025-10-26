using Microsoft.AspNetCore.Mvc;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.UI.Controllers
{
    public class CitaController : Controller
    {
        private readonly IListarCitaLN _listarCitaLN;
        private readonly ICrearCitaLN _crearCitaLN;
        private readonly IEliminarCitaLN _eliminarCitaLN;
        private readonly IObtenerCitaPorIdLN _obtenerCitaPorIdLN;
        private readonly IModificarCitaLN _modificarCitaLN;

        public CitaController(IListarCitaLN listarCitaLN, IEliminarCitaLN eliminarCitaLN, ICrearCitaLN crearCitaLN, IObtenerCitaPorIdLN obtenerCitaPorIdLN, IModificarCitaLN modificarCitaLN)
        {
            _listarCitaLN = listarCitaLN;
            _crearCitaLN = crearCitaLN;
            _eliminarCitaLN = eliminarCitaLN;
            _obtenerCitaPorIdLN = obtenerCitaPorIdLN;
            _modificarCitaLN = modificarCitaLN;
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

        [HttpPost]
        public async Task<IActionResult> CrearCita(CitaDTO cita)
        {
            var resultado = await _crearCitaLN.Crear(cita);
            return Json(resultado);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarCita(string citaId)
        {
            var resultado = await _eliminarCitaLN.Eliminar(citaId);
            return Json(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCitaPorId(string citaId)
        {
            var resultado = await _obtenerCitaPorIdLN.Obtener(Guid.Parse(citaId));
            return Json(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarCita(CitaDTO cita)
        {
            var resultado = await _modificarCitaLN.Modificar(cita);
            return Json(resultado);
        }
    }
}
