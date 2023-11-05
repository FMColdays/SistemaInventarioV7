using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(80, ErrorMessage = "El nombre solo puede tener un maximo de 80 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(80, ErrorMessage = "El apellido solo puede tener un maximo de 80 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength(200, ErrorMessage = "La dirección solo puede tener un maximo de 200 caracteres")]
        public string Direccion { get; set;}

        [Required(ErrorMessage = "La ciudad es requerida")]
        [MaxLength(60, ErrorMessage = "La ciudad solo puede tener un maximo de 80 caracteres")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El país es requerido")]
        [MaxLength(60, ErrorMessage = "El país solo puede tener un maximo de 60 caracteres")]
        public string Pais { get; set; }

        [NotMapped] //No se agrega a la base de datos
        public string Rol { get; set; }
    }
}
