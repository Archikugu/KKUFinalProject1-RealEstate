using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfImagesRepository : GenericRepository<Images, DataContext>, IImagesRepository
    {
        private DataContext context;
        public EfImagesRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
