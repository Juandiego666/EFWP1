using System.ComponentModel.DataAnnotations;

namespace EFWP1.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Propiedad de navegación: Una categoría contiene muchos productos
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}