using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.DataAccess.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> List();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
