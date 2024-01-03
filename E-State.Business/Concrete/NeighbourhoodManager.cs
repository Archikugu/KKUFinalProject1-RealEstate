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
    public class NeighbourhoodManager : INeighbourhoodService
    {
        INeighbourhoodRepository _neighbourhoodRepository;

        public NeighbourhoodManager(INeighbourhoodRepository neighbourhoodRepository)
        {
            _neighbourhoodRepository = neighbourhoodRepository;
        }

        public void Add(Neighbourhood item)
        {
            item.Status = true;
            _neighbourhoodRepository.Add(item);
        }

        public void Delete(Neighbourhood item)
        {
            var neigh = _neighbourhoodRepository.GetById(item.NeighbourhoodId);
            neigh.Status = false;
            _neighbourhoodRepository.Update(item);
        }

        public void FullDelete(Neighbourhood item)
        {
            var delete = _neighbourhoodRepository.GetById(item.NeighbourhoodId);
            _neighbourhoodRepository.FullDelete(delete);
        }

        public void GetActive(Neighbourhood item)
        {
            var active = _neighbourhoodRepository.GetById(item.NeighbourhoodId);
            _neighbourhoodRepository.GetActive(active);
        }

        public Neighbourhood GetById(int id)
        {

            return _neighbourhoodRepository.GetById(id);
        }

        public List<Neighbourhood> List()
        {
            return _neighbourhoodRepository.List();
        }

        public List<Neighbourhood> List(Expression<Func<Neighbourhood, bool>> filter)
        {
            return _neighbourhoodRepository.List(filter);
        }

        public void Update(Neighbourhood item)
        {
            var neigh = _neighbourhoodRepository.GetById(item.NeighbourhoodId);
            neigh.NeighbourhoodName = item.NeighbourhoodName;
            neigh.DistrictKey = item.DistrictKey;

            _neighbourhoodRepository.Update(neigh);
        }
    }
}
