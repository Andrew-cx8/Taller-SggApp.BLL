using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPresupuestoService
{
    Task<IEnumerable<Presupuesto>> ObtenerTodosAsync();
    Task<Presupuesto> ObtenerPorIdAsync(int id);
    Task<IEnumerable<Presupuesto>> ObtenerPorUsuarioAsync(int usuarioId);
    Task AgregarAsync(Presupuesto presupuesto);
    Task ActualizarAsync(Presupuesto presupuesto);
    Task EliminarAsync(int id);
}
