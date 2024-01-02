using E_State.Entities.Entities;

namespace E_State.DataAccess.Abstract
{
    public interface IDistrictRepository : IRepository<District>
    {
        public void FullDelete(District item);
        public void GetActive(District item);
    }
}
