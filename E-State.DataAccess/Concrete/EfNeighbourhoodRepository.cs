using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfNeighbourhoodRepository : GenericRepository<Neighbourhood, DataContext>, INeighbourhoodRepository
    {
        private DataContext context;
        public EfNeighbourhoodRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void FullDelete(Neighbourhood item)
        {
            var neigh = context.Neighbourhoods.Find(item.NeighbourhoodId);
            context.Neighbourhoods.Remove(neigh);
            context.SaveChanges();
        }

        public void GetActive(Neighbourhood item)
        {
            var neigh = context.Neighbourhoods.Find(item.NeighbourhoodId);

            if (neigh.Status == false)
            {
                neigh.Status = true;
                context.Neighbourhoods.Update(neigh);
                context.SaveChanges();
            }
        }
    }
}
