using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.Abstract
{
    public interface IGenericService<T>
    {
        List<T> List();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int id);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
