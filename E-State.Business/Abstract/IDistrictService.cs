using E_State.Entities.Entities;

namespace E_State.Business.Abstract
{
    public interface IDistrictService : IGenericService<District>
    {
        public void FullDelete(District item);
        public void GetActive(District item);
    }
}
