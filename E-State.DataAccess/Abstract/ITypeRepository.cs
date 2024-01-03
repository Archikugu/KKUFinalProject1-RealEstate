using E_State.Entities.Entities;

namespace E_State.DataAccess.Abstract
{
    public interface ITypeRepository : IRepository<Entities.Entities.Type>
    {
        public void FullDelete(Entities.Entities.Type item);
        public void GetActive(Entities.Entities.Type item);
    }
}
