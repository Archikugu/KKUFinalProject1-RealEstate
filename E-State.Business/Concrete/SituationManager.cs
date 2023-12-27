using E_State.Business.Abstract;
using E_State.DataAccess.Abstract;
using E_State.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.Concrete
{
    public class SituationManager : ISituationService
    {
        ISituaitonRepository _situationRepository;

        public SituationManager(ISituaitonRepository situationRepository)
        {
            _situationRepository = situationRepository;
        }

        public void Add(Situation item)
        {
            _situationRepository.Add(item);
        }

        public void Delete(Situation item)
        {
            _situationRepository.Delete(item);
        }

        public Situation GetById(int id)
        {
            return _situationRepository.GetById(id);
        }

        public List<Situation> List()
        {
            return _situationRepository.List();
        }

        public List<Situation> List(Expression<Func<Situation, bool>> filter)
        {
            return _situationRepository.List(filter);
        }

        public void Update(Situation item)
        {
            _situationRepository.Update(item);
        }
    }
}
