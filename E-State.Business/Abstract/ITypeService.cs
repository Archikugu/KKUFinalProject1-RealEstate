using E_State.Entities.Entities;

namespace E_State.Business.Abstract
{
    public interface ITypeService : IGenericService<Entities.Entities.Type>
    {
        public void FullDelete(Entities.Entities.Type item);
        public void GetActive(Entities.Entities.Type item);
    }
}
