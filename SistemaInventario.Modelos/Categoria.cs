using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre es requerido")]
        [MaxLength(60, ErrorMessage ="Nombre debe ser un maximo de 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="La descripción es requerida")]
        [MaxLength(100, ErrorMessage ="La descripción solo puede tener un maximo de 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El estado es requerido")]
        public bool Estado { get; set; }


    }
}
