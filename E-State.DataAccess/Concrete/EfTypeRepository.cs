using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;

namespace E_State.DataAccess.Concrete
{
    public class EfTypeRepository : GenericRepository<Entities.Entities.Type, DataContext>, ITypeRepository
    {
        private DataContext context;
        public EfTypeRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }

}
