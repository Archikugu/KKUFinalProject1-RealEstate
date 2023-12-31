using E_State.Entities.Entities;

namespace E_State.DataAccess.Abstract
{
    public interface ICityRepository : IRepository<City>
    {
        public void FullDelete(City item);
        public void GetActive (City item);

    }
}
