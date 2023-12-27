using E_State.Entities.Entities;

namespace E_State.Business.Abstract
{
    public interface IAdvertService : IGenericService<Advert>
    {
        public void RestoreDelete(Advert item);
        public void FullDelete(Advert item);
    }
}
