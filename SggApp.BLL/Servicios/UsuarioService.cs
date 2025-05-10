public class UsuarioService : IUsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioService(UsuarioRepository repo)
    {
        _usuarioRepository = repo;
    }

    public async Task<IEnumerable<Usuario>> ObtenerTodosAsync() =>
        await _usuarioRepository.GetAllAsync();

    public async Task<Usuario> ObtenerPorIdAsync(int id) =>
        await _usuarioRepository.GetByIdAsync(id);

    public async Task<Usuario> ObtenerPorEmailAsync(string email) =>
        await _usuarioRepository.GetByConditionAsync(u => u.Email == email).ContinueWith(t => t.Result.FirstOrDefault());

    public async Task AgregarAsync(Usuario usuario) =>
        await _usuarioRepository.AddAsync(usuario);

    public async Task ActualizarAsync(Usuario usuario) =>
        _usuarioRepository.Update(usuario);

    public async Task EliminarAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario != null)
            _usuarioRepository.Delete(usuario);
    }
}
