using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El campo nombre solo puede tener un maximo de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(100, ErrorMessage = "El campo descripción solo puede tener un maximo de 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El estado es requerido")]
        public bool Estado { get; set; }
    }
}
