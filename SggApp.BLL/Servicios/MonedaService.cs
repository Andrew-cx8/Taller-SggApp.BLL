public class MonedaService : IMonedaService
{
    private readonly MonedaRepository _monedaRepository;

    public MonedaService(MonedaRepository repo)
    {
        _monedaRepository = repo;
    }

    public async Task<IEnumerable<Moneda>> ObtenerTodasAsync() =>
        await _monedaRepository.GetAllAsync();

    public async Task<Moneda> ObtenerPorIdAsync(int id) =>
        await _monedaRepository.GetByIdAsync(id);

    public async Task AgregarAsync(Moneda moneda) =>
        await _monedaRepository.AddAsync(moneda);

    public async Task ActualizarAsync(Moneda moneda) =>
        _monedaRepository.Update(moneda);

    public async Task EliminarAsync(int id)
    {
        var moneda = await _monedaRepository.GetByIdAsync(id);
        if (moneda != null)
            _monedaRepository.Delete(moneda);
    }
}
