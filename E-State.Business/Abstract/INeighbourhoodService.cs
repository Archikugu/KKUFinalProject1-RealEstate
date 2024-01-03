using E_State.Entities.Entities;

namespace E_State.Business.Abstract
{
    public interface INeighbourhoodService : IGenericService<Neighbourhood>
    {
        public void FullDelete(Neighbourhood item);
        public void GetActive(Neighbourhood item);
    }
}
