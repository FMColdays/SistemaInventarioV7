using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El numero de serie es requerido")]
        [MaxLength(60, ErrorMessage ="El numero de serie solo puede tener un maximo de 60 caracteres")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(60, ErrorMessage = "La descripcion solo puede tener un maximo de 60 caracteres")]
        public string Descripcion {  get; set; }

        [Required(ErrorMessage="El precio es requerido")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El costo es requerido")]
        public double Costo {  get; set; }

        public string ImagenUrl {  get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado {  get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "La marca es requerida")]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        public int? PadreId { get; set; }
        public virtual Producto Padre { get; set; }
    }
}
