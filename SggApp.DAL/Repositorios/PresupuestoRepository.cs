using SggApp.DAL.Contextos;
using SggApp.DAL.Entidades;

namespace SggApp.DAL.Repositorios
{
    public class PresupuestoRepository : GenericRepository<Presupuesto>
    {
        public PresupuestoRepository(SggAppContext context) : base(context) { }
    }
}
