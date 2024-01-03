using E_State.Entities.Entities;

namespace E_State.DataAccess.Abstract
{
    public interface INeighbourhoodRepository : IRepository<Neighbourhood>
    {
        public void FullDelete(Neighbourhood item);
        public void GetActive(Neighbourhood item);
    }
}
