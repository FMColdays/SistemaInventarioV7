using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventario.Utilidades;

namespace SistemaInventarioV7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {

        private readonly IUnidadTrabajo _unidadaTrabajo;

        public CategoriaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadaTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Categoria categoria = new Categoria();

            if (id == null)
            {
                categoria.Estado = true;
                return View(categoria);
            }
            else
            {
                categoria = await _unidadaTrabajo.Categoria.Obtener(id.GetValueOrDefault());
                if (categoria == null)
                {
                    return NotFound();
                }
                return View(categoria);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if(categoria.Id == 0)
                {
                    await _unidadaTrabajo.Categoria.Agregar(categoria);
                    TempData[DS.Exitosa] = "Categoría creada exitosamente";
                }
                else
                {
                    _unidadaTrabajo.Categoria.Actualizar(categoria);
                    TempData[DS.Exitosa] = "Categoría actualizada exitosamente";
                }
                await _unidadaTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Exitosa] = "Error al grabar Categoría";
            return View(categoria);    
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadaTrabajo.Categoria.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaDB = await _unidadaTrabajo.Categoria.Obtener(id);

            if(categoriaDB == null)
            {
                return Json(new {success = false, message= "Error al borrar la categoría"});
            }

            _unidadaTrabajo.Categoria.Remover(categoriaDB);
            await _unidadaTrabajo.Guardar();
            return Json(new { success = true, message = "Categoría borrada exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadaTrabajo.Categoria.ObtenerTodos();

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
