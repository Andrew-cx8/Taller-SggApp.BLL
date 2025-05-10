using System.Collections.Generic;

namespace SggApp.DAL.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
        public ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
    }
}
