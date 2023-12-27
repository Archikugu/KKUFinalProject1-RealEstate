using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.DataAccess.Concrete
{
    public class GenericRepository<T, TContext> : IRepository<T> where T : class, new() where TContext : DbContext, new()
    {
        private readonly DataContext context = new DataContext();
        DbSet<T> _object;
        public GenericRepository(DataContext context)
        {
            this.context = context;
            _object = context.Set<T>();
        }

        public void Add(T item)
        {
            _object.Add(item);
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            _object.Remove(item);
            context.SaveChanges();
        }
        public void Update(T item)
        {
            _object.Update(item);
            context.SaveChanges();
        }
        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
