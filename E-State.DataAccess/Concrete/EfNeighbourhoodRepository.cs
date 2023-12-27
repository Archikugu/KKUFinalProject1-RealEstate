﻿using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfNeighbourhoodRepository : GenericRepository<Neighbourhood, DataContext>, INeighbourhoodRepository
    {
        private DataContext context;
        public EfNeighbourhoodRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
