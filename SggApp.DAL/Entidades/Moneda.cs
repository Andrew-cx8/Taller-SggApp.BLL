using System.Collections.Generic;

namespace SggApp.DAL.Entidades
{
    public class Moneda
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;  // e.g., USD, EUR
        public string Simbolo { get; set; } = string.Empty; // e.g., $, €

        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
        public ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
    }
}
