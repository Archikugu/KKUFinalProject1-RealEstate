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
    public class AdvertManager : IAdvertService
    {
        IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public void Add(Advert item)
        {
            item.Status = true;
            item.AdvertDate = DateTime.Now;
            _advertRepository.Add(item);

        }

        public void Delete(Advert item)
        {
            var delete = _advertRepository.GetById(item.AdvertId);
            item.Status = false;
            _advertRepository.Update(delete);
        }

        public Advert GetById(int id)
        {
            return _advertRepository.GetById(id);
        }

        public List<Advert> List()
        {
            return _advertRepository.List();
        }

        public List<Advert> List(Expression<Func<Advert, bool>> filter)
        {
            return _advertRepository.List(filter);
        }

        public void Update(Advert item)
        {
            var advert = _advertRepository.GetById(item.AdvertId);
            advert.Address = item.Address;
            advert.Descriptions = item.Descriptions;
            advert.BathroomNumbers = item.BathroomNumbers;
            advert.NumberOfRooms = item.NumberOfRooms;
            advert.Floor = item.Floor;
            advert.Garage = item.Garage;
            advert.AirCordinator = item.AirCordinator;
            advert.Garden = item.Garden;
            advert.Fireplace = item.Fireplace;
            advert.Firnutere = item.Firnutere;
            advert.Area = item.Area;
            advert.Pool = item.Pool;
            advert.Teras = item.Teras;
            advert.DistrictId = item.DistrictId;
            advert.CityId = item.CityId;
            advert.NeighbourhoodId = item.NeighbourhoodId;
            advert.PhoneNumber = item.PhoneNumber;
            advert.AdvertDate = DateTime.Now;
            advert.SituationId = item.SituationId;
            advert.TypeId = item.TypeId;

            _advertRepository.Update(advert);
        }

        public void RestoreDelete(Advert item)
        {
            var delete = _advertRepository.GetById(item.AdvertId);
            item.Status = true;
            _advertRepository.Update(delete);
        }
        public void FullDelete(Advert item)
        {
            var delete = _advertRepository.GetById(item.AdvertId);
            _advertRepository.FullDelete(delete);
        }

    }
}
