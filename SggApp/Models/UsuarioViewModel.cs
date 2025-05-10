// Usuario ViewModels
using System;
using System.ComponentModel.DataAnnotations;
namespace SggApp.API.Models
{
// ViewModel para mostrar información de usuarios
public class UsuarioViewModel
{
public int Id { get; set; }
[Display(Name = "Nombre")]
public string Nombre { get; set; }
[Display(Name = "Correo Electrónico")]
public string Email { get; set; }
[Display(Name = "Fecha de Registro")]
[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
public DateTime FechaRegistro { get; set; }
}
// ViewModel para crear/editar usuarios
public class UsuarioFormViewModel
{
public int Id { get; set; }
[Required(ErrorMessage = "El nombre es obligatorio")]
[StringLength(100, ErrorMessage = "El nombre no puede tener más de 100
caracteres")]
[Display(Name = "Nombre")]
public string Nombre { get; set; }
[Required(ErrorMessage = "El correo electrónico es obligatorio")]
[EmailAddress(ErrorMessage = "El formato del correo electrónico no es
válido")]
[Display(Name = "Correo Electrónico")]
public string Email { get; set; }
[Required(ErrorMessage = "La contraseña es obligatoria")]
[StringLength(100, ErrorMessage = "La contraseña debe tener entre {2} y
{1} caracteres", MinimumLength = 6)]
[DataType(DataType.Password)]
[Display(Name = "Contraseña")]
public string Password { get; set; }
[DataType(DataType.Password)]
[Display(Name = "Confirmar contraseña")]
[Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
public string ConfirmPassword { get; set; }
}
}