using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> ObtenerTodasAsync();
    Task<Categoria> ObtenerPorIdAsync(int id);
    Task AgregarAsync(Categoria categoria);
    Task ActualizarAsync(Categoria categoria);
    Task EliminarAsync(int id);
}