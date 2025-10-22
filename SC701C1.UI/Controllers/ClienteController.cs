using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IListarClienteLN _listarClienteLN;
        private readonly IObtenerClientePorIdentificacionLN _obtenerClientePorIdentificacionLN;
        private readonly IEliminarClienteLN _eliminarClienteLN;
        private readonly IModificarClienteLN _modificarClienteLN;

        public ClienteController(IListarClienteLN listarClienteLN, IObtenerClientePorIdentificacionLN obtenerClientePorIdentificacionLN, IEliminarClienteLN eliminarClienteLN, IModificarClienteLN modificarClienteLN)
        {
            _listarClienteLN = listarClienteLN;
            _obtenerClientePorIdentificacionLN = obtenerClientePorIdentificacionLN;
            _eliminarClienteLN = eliminarClienteLN;
            _modificarClienteLN = modificarClienteLN;
        }

        //---------------------------------------------------
        // GET: ClienteController
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var respuesta = await _listarClienteLN.Listar();
            return Json(respuesta);
        }

        public async Task<IActionResult> ObtenerClientePorIdentificacion(int identificacion)
        {
            var respuesta = await _obtenerClientePorIdentificacionLN.Obtener(identificacion);
            return Json(respuesta);
        }

        // GET: ClienteController/Detalles/5
        public ActionResult DetallesCliente()
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarCliente(ClienteDTO cliente)
        {
            var respuesta = await _modificarClienteLN.Modificar(cliente);
            return Json(respuesta);
        }

        // Delete: ClienteController/EliminarCliente/5
        [HttpDelete]
        public async Task<IActionResult> EliminarCliente(int identificacion)
        {
            var respuesta = await _eliminarClienteLN.Eliminar(identificacion);
            return Json(respuesta);
        }
    }
}
