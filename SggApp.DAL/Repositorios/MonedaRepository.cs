using SggApp.DAL.Contextos;
using SggApp.DAL.Entidades;

namespace SggApp.DAL.Repositorios
{
    public class MonedaRepository : GenericRepository<Moneda>
    {
        public MonedaRepository(SggAppContext context) : base(context) { }
    }
}
