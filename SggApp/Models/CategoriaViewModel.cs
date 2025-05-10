using System.ComponentModel.DataAnnotations;
namespace SggApp.API.Models
{
// ViewModel para mostrar categorías
public class CategoriaViewModel
{
public int Id { get; set; }
[Display(Name = "Nombre")]
public string Nombre { get; set; }
}
// ViewModel para formularios de creación y edición de categorías
public class CategoriaFormViewModel
{
public int Id { get; set; }
[Required(ErrorMessage = "El nombre es obligatorio")]
[StringLength(50, ErrorMessage = "El nombre no puede tener más de 50
caracteres")]
[Display(Name = "Nombre")]
public string Nombre { get; set; }
}
}