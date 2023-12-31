using E_State.Entities.Entities;

namespace E_State.Business.Abstract
{
    public interface ICityService : IGenericService<City>
    {
        public void FullDelete(City item);
        public void GetActive(City item);

    }
}
