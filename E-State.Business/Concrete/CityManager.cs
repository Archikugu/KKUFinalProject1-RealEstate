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
    public class CityManager : ICityService
    {
        ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Add(City item)
        {
            _cityRepository.Add(item);
        }

        public void Delete(City item)
        {
            _cityRepository.Delete(item);
        }

        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public List<City> List()
        {
            return _cityRepository.List();
        }

        public List<City> List(Expression<Func<City, bool>> filter)
        {
            return _cityRepository.List(filter);
        }

        public void Update(City item)
        {
            _cityRepository.Update(item);
        }
    }
}
