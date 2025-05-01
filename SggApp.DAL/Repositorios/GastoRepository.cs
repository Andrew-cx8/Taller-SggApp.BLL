using Microsoft.EntityFrameworkCore;
using SggApp.DAL.Contextos;
namespace SggApp.DAL.Repositorios
{
public class GastoRepository : GenericRepository<Gasto>
{
public GastoRepository(SggAppContext context) : base(context)
{
}
}
}