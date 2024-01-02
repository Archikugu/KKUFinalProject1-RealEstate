using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfDistrictRepository : GenericRepository<District, DataContext>, IDistrictRepository
    {
        private DataContext context;
        public EfDistrictRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void FullDelete(District item)
        {
            var district = context.Districts.Find(item.DistrictId);
            context.Districts.Remove(district);
            context.SaveChanges();
        }

        public void GetActive(District item)
        {
            var district = context.Districts.Find(item.DistrictId);

            if (district.Status == false)
            {
                district.Status = true;
                context.Districts.Update(district);
                context.SaveChanges();
            }
        }
    }
}
