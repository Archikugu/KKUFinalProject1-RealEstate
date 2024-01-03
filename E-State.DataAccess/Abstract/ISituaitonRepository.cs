using E_State.Entities.Entities;

namespace E_State.DataAccess.Abstract
{
    public interface ISituaitonRepository : IRepository<Situation>
    {
        public void FullDelete(Situation item);
        public void GetActive(Situation item);
    }
}
