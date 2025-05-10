using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMonedaService
{
    Task<IEnumerable<Moneda>> ObtenerTodasAsync();
    Task<Moneda> ObtenerPorIdAsync(int id);
    Task AgregarAsync(Moneda moneda);
    Task ActualizarAsync(Moneda moneda);
    Task EliminarAsync(int id);
}
