using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.RateLimiting;

namespace WebApiDemokrataPerson.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El primer nombre no puede contener números.")]
        public string Nombre { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo nombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El segundo nombre no puede contener números.")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer apellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El primer apellido no puede contener números.")]
        public string Apellido { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo apellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El segundo apellido no puede contener números.")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateOnly FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El sueldo debe ser mayor que 0.")]
        public int Sueldo { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

        public void UpdateFechaActualizacion()
        {
            FechaActualizacion = DateTime.UtcNow;
        }

    }
}
