using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfCityRepository : GenericRepository<City, DataContext>, ICityRepository
    {
        private DataContext context;
        public EfCityRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
