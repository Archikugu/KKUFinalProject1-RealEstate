using E_State.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.DataAccess.Abstract
{
    public interface IAdvertRepository : IRepository<Advert>
    {
        public void FullDelete(Advert item);
    }
}
