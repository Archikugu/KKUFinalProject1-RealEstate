using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfCityRepository : GenericRepository<City, DataContext>, ICityRepository
    {
        private DataContext context;
        public EfCityRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void FullDelete(City item)
        {
            var city = context.Cities.Find(item.CityId);
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public void GetActive(City item)
        {
            var city = context.Cities.Find(item.CityId);

            if (city.Status == false)
            {
                city.Status = true;
                context.Cities.Update(city);
                context.SaveChanges();
            }
        }
    }
}
