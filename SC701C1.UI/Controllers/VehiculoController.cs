using Microsoft.AspNetCore.Mvc;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.UI.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly IObtenerVehiculosLN _obtenerVehiculosLN;
        private readonly ICrearVehiculoLN _crearVehiculoLN;
        private readonly IEliminarVehiculoLN _eliminarVehiculoLN;

        public VehiculoController(IObtenerVehiculosLN obtenerVehiculosLN, ICrearVehiculoLN crearVehiculoLN, IEliminarVehiculoLN eliminarVehiculoLN)
        {
            _obtenerVehiculosLN = obtenerVehiculosLN;
            _crearVehiculoLN = crearVehiculoLN;
            _eliminarVehiculoLN = eliminarVehiculoLN;
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

        [HttpPost]
        public async Task<IActionResult> CrearVehiculo(VehiculoDTO vehiculo )
        {
            var respuesta = await _crearVehiculoLN.Crear(vehiculo);
            return Json(respuesta);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarVehiculo(string placa)
        {
            var respuesta = await _eliminarVehiculoLN.Eliminar(placa);
            return Json(respuesta);
        }
    }
}
