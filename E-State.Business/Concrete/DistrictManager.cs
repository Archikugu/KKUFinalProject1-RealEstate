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
    public class DistrictManager : IDistrictService
    {
        IDistrictRepository _districtRepository;

        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public void Add(District item)
        {

            item.Status = true;
            _districtRepository.Add(item);
        }

        public void Delete(District item)
        {
            var delete = _districtRepository.GetById(item.DistrictId);
            delete.Status = false;
            _districtRepository.Update(delete);
        }

        public void FullDelete(District item)
        {
            var delete = _districtRepository.GetById(item.DistrictId);
            _districtRepository.FullDelete(delete);
        }

        public void GetActive(District item)
        {
            var active = _districtRepository.GetById(item.DistrictId);
            _districtRepository.GetActive(active);
        }

        public District GetById(int id)
        {
            return _districtRepository.GetById(id);
        }

        public List<District> List()
        {
            return _districtRepository.List();
        }

        public List<District> List(Expression<Func<District, bool>> filter)
        {
            return _districtRepository.List(filter);
        }

        public void Update(District item)
        {
            var district = _districtRepository.GetById(item.DistrictId);
            district.DistrictName = item.DistrictName;
            district.City.CityId = item.CityKey;

            _districtRepository.Update(item);
        }
    }
}
