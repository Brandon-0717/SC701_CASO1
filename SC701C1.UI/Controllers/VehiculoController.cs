using Microsoft.AspNetCore.Mvc;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.UI.Controllers
{
    public class VehiculoController : Controller
    {
        IObtenerVehiculosLN _obtenerVehiculosLN;

        public VehiculoController(IObtenerVehiculosLN obtenerVehiculosLN)
        {
            _obtenerVehiculosLN = obtenerVehiculosLN;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerVehiculos()
        {
            var respuesta = await _obtenerVehiculosLN.Obtener();
            return Json(respuesta);
        }

        public async Task<IActionResult> CrearVehiculo(VehiculoDTO vehiculo )
        {
            return View();
        }
    }
}
