using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaInventario.Modelos.ViewModels
{
    public class InventarioVM
    {
        public Inventario Inventario { get; set; }
        public InventarioDetalle InventarioDetalle { get; set; }
        public IEnumerable<InventarioDetalle> InventarioDetalles { get; set; }
        public IEnumerable<SelectListItem> BodegaLista { get; set; }
    }
}
