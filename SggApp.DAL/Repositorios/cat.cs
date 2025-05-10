using SggApp.DAL.Contextos;
using SggApp.DAL.Entidades;

namespace SggApp.DAL.Repositorios
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(SggAppContext context) : base(context) { }
    }
}
