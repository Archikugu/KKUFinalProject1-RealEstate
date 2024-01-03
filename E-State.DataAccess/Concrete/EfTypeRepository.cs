using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;

namespace E_State.DataAccess.Concrete
{
    public class EfTypeRepository : GenericRepository<Entities.Entities.Type, DataContext>, ITypeRepository
    {
        private DataContext context;
        public EfTypeRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void FullDelete(Entities.Entities.Type item)
        {
            var type = context.Types.Find(item.TypeId);
            context.Types.Remove(type);
            context.SaveChanges();
        }

        public void GetActive(Entities.Entities.Type item)
        {
            var type = context.Types.Find(item.TypeId);

            if (type.Status == false)
            {
                type.Status = true;
                context.Types.Update(type);
                context.SaveChanges();
            }
        }
    }

}
