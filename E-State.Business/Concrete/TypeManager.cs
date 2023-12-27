using E_State.Business.Abstract;
using E_State.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.Concrete
{
    public class TypeManager : ITypeService
    {
        ITypeRepository _typeRepository;

        public TypeManager(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public void Add(Entities.Entities.Type item)
        {
            _typeRepository.Add(item);
        }

        public void Delete(Entities.Entities.Type item)
        {
            _typeRepository?.Delete(item);
        }

        public Entities.Entities.Type GetById(int id)
        {
            return _typeRepository.GetById(id);
        }

        public List<Entities.Entities.Type> List()
        {
            return _typeRepository.List();
        }

        public List<Entities.Entities.Type> List(Expression<Func<Entities.Entities.Type, bool>> filter)
        {
            return _typeRepository.List(filter);
        }

        public void Update(Entities.Entities.Type item)
        {
            _typeRepository.Update(item);
        }
    }
}
