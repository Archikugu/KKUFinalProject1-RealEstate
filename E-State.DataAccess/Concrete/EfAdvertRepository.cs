using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.DataAccess.Concrete
{
    public class EfAdvertRepository : GenericRepository<Advert, DataContext>, IAdvertRepository
    {
        private DataContext context;
        public EfAdvertRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public void FullDelete(Advert item)
        {
            var advert = context.Adverts.Find(item.AdvertId);
            context.Adverts.Remove(advert);
            context.SaveChanges();
        }
    }
}
