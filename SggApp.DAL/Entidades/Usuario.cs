using System;
using System.Collections.Generic;
namespace SggApp.DAL.Entidades
{
public class Usuario
{
// Propiedades principales
public int Id { get; set; } // Clave primaria
public string Nombre { get; set; } // Nombre completo del usuario
public string Email { get; set; } // Correo electrónico (único)
public string PasswordHash { get; set; } // Contraseña (cifrada???)
public DateTime FechaRegistro { get; set; } // Fecha de registro
// Relaciones
public ICollection<Gasto> Gastos { get; set; } // Un usuario puede tener
muchos gastos
public ICollection<Presupuesto> Presupuestos { get; set; } // Un usuario
puede tener muchos presupuestos
}
}