// Moneda ViewModels
using System.ComponentModel.DataAnnotations;
namespace SggApp.API.Models
{
// ViewModel para mostrar monedas
public class MonedaViewModel
{
public int Id { get; set; }
[Display(Name = "Nombre")]
public string Nombre { get; set; }
[Display(Name = "Código")]
public string Codigo { get; set; }
}
// ViewModel para formularios de creación y edición de monedas
public class MonedaFormViewModel
{
public int Id { get; set; }
[Required(ErrorMessage = "El nombre es obligatorio")]
[StringLength(50, ErrorMessage = "El nombre no puede tener más de 50
caracteres")]
[Display(Name = "Nombre")]
public string Nombre { get; set; }
[Required(ErrorMessage = "El código es obligatorio")]
[StringLength(3, MinimumLength = 3, ErrorMessage = "El código debe tener
exactamente 3 caracteres")]
[Display(Name = "Código")]
public string Codigo { get; set; }
}
}