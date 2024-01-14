using E_State.Business.Abstract;
using E_State.Entities.Entities;
using E_State.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace E_State.UI.Controllers
{
    public class HomeController : Controller
    {
        IAdvertService _advertService;
        ICityService _cityService;
        IDistrictService _districtService;
        INeighbourhoodService _neighbourhoodService;
        ISituationService _situationService;
        ITypeService _typeService;
        IImagesService _imagesService;


        public HomeController(IAdvertService advertService, ICityService cityService, IDistrictService districtService, INeighbourhoodService neighbourhoodService, ISituationService situationService, ITypeService typeService, IImagesService imagesService)
        {
            _advertService = advertService;
            _cityService = cityService;
            _districtService = districtService;
            _neighbourhoodService = neighbourhoodService;
            _situationService = situationService;
            _typeService = typeService;
            _imagesService = imagesService;
        }

        public IActionResult Index()
        {
            DropDown();
            return View();
        }
        public IActionResult Filtre(int min, int max, int cityid, int typeid, int neighbourhoodid, int districtid, int situationid)
        {
            DropDown();
            var imagelist = _imagesService.List(x => x.Status == true);
            ViewBag.images = imagelist;
            var filter = _advertService.List(x => x.Price >= min && x.Price <= max && x.CityId == cityid && x.TypeId == typeid && x.NeighbourhoodId == neighbourhoodid && x.DistrictId == districtid && x.SituationId == situationid);
            return View(filter);
        }
        public PartialViewResult PartialFiltre()
        {
            DropDown();
            return PartialView();
        }


        public List<City> CityGet()
        {
            List<City> cityList = _cityService.List(x => x.Status == true);
            return cityList;
        }
        public List<Situation> SituationGet()
        {
            List<Situation> situationList = _situationService.List(x => x.Status == true);
            return situationList;
        }
        public List<Entities.Entities.Type> TypeGet()
        {
            List<Entities.Entities.Type> typeList = _typeService.List(x => x.Status == true);
            return typeList;
        }
        public List<Neighbourhood> NeighbourhoodGet()
        {
            List<Neighbourhood> neighbourhoodList = _neighbourhoodService.List(x => x.Status == true);
            return neighbourhoodList;
        }
        public List<District> DistrictGet()
        {
            List<District> districtList = _districtService.List(x => x.Status == true);
            return districtList;
        }

        public PartialViewResult DistrictPartial()
        {
            return PartialView();
        }
        public PartialViewResult TypePartial()
        {
            return PartialView();
        }
        public PartialViewResult NeighbourhoodPartial()
        {
            return PartialView();
        }

        public IActionResult TypeGet(int SituationId)
        {
            List<Entities.Entities.Type> typeList = _typeService.List(x => x.Status == true && x.SituationId == SituationId);
            ViewBag.typeList = new SelectList(typeList, "TypeId", "TypeName");
            return PartialView("TypePartial");
        }
        public IActionResult DistrictGet(int CityId)
        {
            List<District> districtList = _districtService.List(x => x.Status == true && x.City.CityKey == CityId);
            ViewBag.district = new SelectList(districtList, "DistrictKey", "DistrictName");
            return PartialView("DistrictPartial");

        }
        public IActionResult NeighbourhoodGet(int DistrictId)
        {
            List<Neighbourhood> neighbourhoodList = _neighbourhoodService.List(x => x.Status == true && x.District.DistrictId == DistrictId);
            ViewBag.neighbourhoodList = new SelectList(neighbourhoodList, "NeighbourhoodKey", "NeighbourhoodName");
            return PartialView("NeighbourhoodPartial");
        }

        public void DropDown()
        {
            ViewBag.cities = new SelectList(CityGet(), "CityId", "CityName");
            ViewBag.districtList = new SelectList(DistrictGet(), "DistrictId", "DistrictName");
            ViewBag.situationList = new SelectList(SituationGet(), "SituationId", "SituationName");
            ViewBag.neighbourhoodList = new SelectList(NeighbourhoodGet(), "NeighbourhoodId", "NeighbourhoodName");
            ViewBag.typeList = new SelectList(TypeGet(), "TypeId", "TypeName");



            List<SelectListItem> value1 = (from i in _districtService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.DistrictName,
                                               Value = i.DistrictId.ToString()
                                           }).ToList();
            ViewBag.district = value1;

            List<SelectListItem> value2 = (from i in _neighbourhoodService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.NeighbourhoodName,
                                               Value = i.NeighbourhoodId.ToString()
                                           }).ToList();
            ViewBag.neighbourhood = value2;

            List<SelectListItem> value3 = (from i in _typeService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.TypeName,
                                               Value = i.TypeId.ToString()
                                           }).ToList();
            ViewBag.type = value3;

            List<SelectListItem> value4 = (from i in _situationService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.SituationName,
                                               Value = i.SituationId.ToString()
                                           }).ToList();
            ViewBag.situation = value4;

        }

    }
}
