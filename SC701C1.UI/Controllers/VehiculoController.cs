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
        private readonly IObtenerVehiculoPorPlacaLN _obtenerVehiculoPorPlacaLN;
        private readonly IModificarVehiculoLN _modificarVehiculoLN;

        public VehiculoController(IObtenerVehiculosLN obtenerVehiculosLN, ICrearVehiculoLN crearVehiculoLN, IEliminarVehiculoLN eliminarVehiculoLN, IObtenerVehiculoPorPlacaLN obtenerVehiculoPorPlacaLN, IModificarVehiculoLN modificarVehiculoLN)
        {
            _obtenerVehiculosLN = obtenerVehiculosLN;
            _crearVehiculoLN = crearVehiculoLN;
            _eliminarVehiculoLN = eliminarVehiculoLN;
            _obtenerVehiculoPorPlacaLN = obtenerVehiculoPorPlacaLN;
            _modificarVehiculoLN = modificarVehiculoLN;
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

        [HttpGet]
        public async Task<IActionResult> ObtenerVehiculoPorPlaca(string placa)
        {
            var respuesta = await _obtenerVehiculoPorPlacaLN.Obtener(placa);
            return Json(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ModificarVehiculo(VehiculoDTO vehiculo)
        {
            var respuesta = await _modificarVehiculoLN.Modificar(vehiculo);
            return Json(respuesta);
        }
    }
}
