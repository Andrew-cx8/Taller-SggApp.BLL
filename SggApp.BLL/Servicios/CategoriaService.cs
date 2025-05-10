public class CategoriaService : ICategoriaService
{
    private readonly CategoriaRepository _categoriaRepository;

    public CategoriaService(CategoriaRepository repo)
    {
        _categoriaRepository = repo;
    }

    public async Task<IEnumerable<Categoria>> ObtenerTodasAsync() =>
        await _categoriaRepository.GetAllAsync();

    public async Task<Categoria> ObtenerPorIdAsync(int id) =>
        await _categoriaRepository.GetByIdAsync(id);

    public async Task AgregarAsync(Categoria categoria) =>
        await _categoriaRepository.AddAsync(categoria);

    public async Task ActualizarAsync(Categoria categoria) =>
        _categoriaRepository.Update(categoria);

    public async Task EliminarAsync(int id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria != null)
            _categoriaRepository.Delete(categoria);
    }
}
