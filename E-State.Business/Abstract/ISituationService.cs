using E_State.Entities.Entities;

namespace E_State.Business.Abstract
{
    public interface ISituationService : IGenericService<Situation>
    {
        public void FullDelete(Situation item);
        public void GetActive(Situation item);
    }
}
