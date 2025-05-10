public class PresupuestoService : IPresupuestoService
{
    private readonly PresupuestoRepository _presupuestoRepository;

    public PresupuestoService(PresupuestoRepository repo)
    {
        _presupuestoRepository = repo;
    }

    public async Task<IEnumerable<Presupuesto>> ObtenerTodosAsync() =>
        await _presupuestoRepository.GetAllAsync();

    public async Task<Presupuesto> ObtenerPorIdAsync(int id) =>
        await _presupuestoRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Presupuesto>> ObtenerPorUsuarioAsync(int usuarioId) =>
        await _presupuestoRepository.GetByConditionAsync(p => p.UsuarioId == usuarioId);

    public async Task AgregarAsync(Presupuesto presupuesto) =>
        await _presupuestoRepository.AddAsync(presupuesto);

    public async Task ActualizarAsync(Presupuesto presupuesto) =>
        _presupuestoRepository.Update(presupuesto);

    public async Task EliminarAsync(int id)
    {
        var presupuesto = await _presupuestoRepository.GetByIdAsync(id);
        if (presupuesto != null)
            _presupuestoRepository.Delete(presupuesto);
    }
}
