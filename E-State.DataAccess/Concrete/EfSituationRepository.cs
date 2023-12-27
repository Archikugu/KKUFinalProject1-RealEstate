using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfSituationRepository : GenericRepository<Situation, DataContext>, ISituaitonRepository
    {
        private DataContext context;
        public EfSituationRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
