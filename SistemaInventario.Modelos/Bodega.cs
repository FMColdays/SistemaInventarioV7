using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Modelos
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre de la bodega es requerido")]
        [MaxLength(60, ErrorMessage ="Solo un máximo de 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(100, ErrorMessage = "Solo un máximo de 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El estado es requerido")]
        public bool Estado { get; set; }

    }
}
