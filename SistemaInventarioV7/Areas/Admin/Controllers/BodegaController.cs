using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Utilidades;

namespace SistemaInventarioV7.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Rol_Admin)]
    public class BodegaController : Controller
    {

        private readonly IUnidadTrabajo _unidadaTrabajo;

        public BodegaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadaTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Bodega bodega = new Bodega();

            if (id == null)
            {
                bodega.Estado = true;
                return View(bodega);
            }
            else
            {
                bodega = await _unidadaTrabajo.Bodega.Obtener(id.GetValueOrDefault());
                if (bodega == null)
                {
                    return NotFound();
                }
                return View(bodega);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if(bodega.Id == 0)
                {
                    await _unidadaTrabajo.Bodega.Agregar(bodega);
                    TempData[DS.Exitosa] = "Bodega creada exitosamente";
                }
                else
                {
                    _unidadaTrabajo.Bodega.Actualizar(bodega);
                    TempData[DS.Exitosa] = "Bodega actualizada exitosamente";
                }
                await _unidadaTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Exitosa] = "Error al grabar bodega";
            return View(bodega);    
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadaTrabajo.Bodega.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bodegaDB = await _unidadaTrabajo.Bodega.Obtener(id);

            if(bodegaDB == null)
            {
                return Json(new {success = false, message= "Error al borrar la bodega"});
            }

            _unidadaTrabajo.Bodega.Remover(bodegaDB);
            await _unidadaTrabajo.Guardar();
            return Json(new { success = true, message = "Bodega borrada exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadaTrabajo.Bodega.ObtenerTodos();

            if(id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id != id);
            }

            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }
        #endregion
    }
}
