// Gasto ViewModels
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace SggApp.API.Models
{
// ViewModel para mostrar gastos en listas y detalles
public class GastoViewModel
{
public int Id { get; set; }
[Display(Name = "Categoría")]
public string NombreCategoria { get; set; }
[Display(Name = "Moneda")]
public string CodigoMoneda { get; set; }
[Display(Name = "Monto")]
[DisplayFormat(DataFormatString = "{0:C}")]
public decimal Monto { get; set; }
[Display(Name = "Fecha")]
[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
public DateTime Fecha { get; set; }
[Display(Name = "Descripción")]
public string Descripcion { get; set; }
}
// ViewModel para formularios de creación y edición de gastos
public class GastoFormViewModel
{
public int Id { get; set; }
[Required(ErrorMessage = "Debe seleccionar una categoría")]
[Display(Name = "Categoría")]
public int CategoriaId { get; set; }
[Required(ErrorMessage = "Debe seleccionar una moneda")]
[Display(Name = "Moneda")]
public int MonedaId { get; set; }
[Required(ErrorMessage = "El monto es obligatorio")]
[Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser
positivo")]
[DataType(DataType.Currency)]
[Display(Name = "Monto")]
public decimal Monto { get; set; }
[Required(ErrorMessage = "La fecha es obligatoria")]
[DataType(DataType.Date)]
[Display(Name = "Fecha")]

public DateTime Fecha { get; set; } = DateTime.Today;
[MaxLength(255, ErrorMessage = "La descripción no puede tener más de 255
caracteres")]
[Display(Name = "Descripción")]
public string Descripcion { get; set; }
// Para poblar los dropdowns en las vistas
public IEnumerable<SelectListItem> CategoriasDisponibles { get; set; }
public IEnumerable<SelectListItem> MonedasDisponibles { get; set; }
}
}