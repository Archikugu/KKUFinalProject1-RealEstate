using E_State.Business.Abstract;
using E_State.DataAccess.Abstract;
using E_State.DataAccess.Concrete;
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
            item.Status = true;
            _situationRepository.Add(item);
        }

        public void Delete(Situation item)
        {
            var status = _situationRepository.GetById(item.SituationId);
            status.Status = false;
            _situationRepository.Update(status);
        }

        public void FullDelete(Situation item)
        {
            var delete = _situationRepository.GetById(item.SituationId);
            _situationRepository.FullDelete(delete);
        }

        public void GetActive(Situation item)
        {
            var active = _situationRepository.GetById(item.SituationId);
            _situationRepository.GetActive(active);
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
            var status = _situationRepository.GetById(item.SituationId);
            status.SituationName = item.SituationName;
            _situationRepository.Update(status);
        }
    }
}
