using SggApp.DAL.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ObtenerTodosAsync();
    Task<Usuario> ObtenerPorIdAsync(int id);
    Task<Usuario> ObtenerPorEmailAsync(string email);
    Task AgregarAsync(Usuario usuario);
    Task ActualizarAsync(Usuario usuario);
    Task EliminarAsync(int id);
}
