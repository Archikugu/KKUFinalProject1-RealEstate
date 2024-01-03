using E_State.Business.Abstract;
using E_State.DataAccess.Abstract;
using E_State.DataAccess.Concrete;
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
            item.Status = true;
            _typeRepository.Add(item);
        }

        public void Delete(Entities.Entities.Type item)
        {
            var deleteStatus = _typeRepository.GetById(item.TypeId);
            deleteStatus.Status = false;
            _typeRepository.Update(deleteStatus);
        }

        public void FullDelete(Entities.Entities.Type item)
        {
            var delete = _typeRepository.GetById(item.TypeId);
            _typeRepository.FullDelete(delete);
        }

        public void GetActive(Entities.Entities.Type item)
        {
            var active = _typeRepository.GetById(item.TypeId);
            _typeRepository.GetActive(active);
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
            var status = _typeRepository.GetById(item.TypeId);

            status.TypeName = item.TypeName;
            status.SituationId = item.SituationId;
            _typeRepository.Update(status);
        }
    }
}
