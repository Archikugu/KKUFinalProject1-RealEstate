using E_State.Business.Abstract;
using E_State.Business.ValidationRules;
using E_State.Entities.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_State.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdvertController : Controller
    {
        IAdvertService _advertService;
        ICityService _cityService;
        IDistrictService _districtService;
        INeighbourhoodService _neighbourhoodService;
        ISituationService _situationService;
        ITypeService _typeService;
        IImagesService _imagesService;

        IWebHostEnvironment hostEnvironment;

        public AdvertController(IAdvertService advertService, ICityService cityService, IDistrictService districtService, INeighbourhoodService neighbourhoodService, ISituationService situationService, ITypeService typeService, IWebHostEnvironment hostEnvironment, IImagesService imagesService)
        {
            _advertService = advertService;
            _cityService = cityService;
            _districtService = districtService;
            _neighbourhoodService = neighbourhoodService;
            _situationService = situationService;
            _typeService = typeService;
            _imagesService = imagesService;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            string id = HttpContext.Session.GetString("Id");

            var list = _advertService.List(x => x.Status == true && x.UserAdminId == id);
            return View(list);
        }

        public IActionResult ImageList(int id)
        {
            var list = _imagesService.List(x => x.Status == true && x.AdvertId == id);
            return View(list);
        }

        [HttpGet]
        public IActionResult ImageCreate(int id)
        {
            var advert = _advertService.GetById(id);
            return View(advert);
        }
        [HttpPost]
        public IActionResult ImageCreate(Advert data)
        {
            var advert = _advertService.GetById(data.AdvertId);

            if (data.Image != null)
            {
                var dosyayolu = Path.Combine(hostEnvironment.WebRootPath, "img");

                foreach (var item in data.Image)
                {
                    var tamDosyaAdi = Path.Combine(dosyayolu, item.FileName);

                    using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
                    {
                        item.CopyTo(dosyaAkisi);
                    }
                    _imagesService.Add(new Images { ImageName = item.FileName, Status = true, AdvertId = advert.AdvertId });
                }


                TempData["Success"] = "İlan Resim Ekleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }


            return View(advert);
        }


        public IActionResult ImageDelete(int id)
        {
            var delete = _imagesService.GetById(id);
            _imagesService.Delete(delete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ImageUpdate(int id)
        {
            var image = _imagesService.GetById(id);
            return View(image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ImageUpdate(Images data)
        {

            ImagesValidation validationRules = new ImagesValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                if (data.Image != null)
                {
                    var dosyayolu = Path.Combine(hostEnvironment.WebRootPath, "img");

                    var tamDosyaAdi = Path.Combine(dosyayolu, data.Image.FileName);

                    using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
                    {
                        data.Image.CopyTo(dosyaAkisi);
                    }
                    _imagesService.Update(data);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteList()
        {
            string id = HttpContext.Session.GetString("Id");

            var list = _advertService.List(x => x.Status == false && x.UserAdminId == id);
            return View(list);
        }

        public IActionResult RestoreDeleted(int id)
        {
            var sessionUser = HttpContext.Session.GetString("Id");

            var delete = _advertService.GetById(id);
            if (sessionUser.ToString() == delete.UserAdminId)
            {
                _advertService.RestoreDelete(delete);
                TempData["RestoreDelete"] = "İlan Geri Yükleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult FullDelete(int id)
        {
            var sessionUser = HttpContext.Session.GetString("Id");

            var delete = _advertService.GetById(id);
            if (sessionUser.ToString() == delete.UserAdminId)
            {
                _advertService.FullDelete(delete);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Create()
        {
            ViewBag.userid = HttpContext.Session.GetString("Id");
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Advert data)
        {
            AdvertValidation validationRules = new AdvertValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                if (data.Image != null)
                {
                    var dosyayolu = Path.Combine(hostEnvironment.WebRootPath, "img");

                    foreach (var item in data.Image)
                    {
                        var tamDosyaAdi = Path.Combine(dosyayolu, item.FileName);

                        using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
                        {
                            item.CopyTo(dosyaAkisi);
                        }
                        data.Images.Add(new Images { ImageName = item.FileName, Status = true });
                    }
                    _advertService.Add(data);

                    TempData["Success"] = "İlan Ekleneme İşlemi Başarı ile Gerçekleşti";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            DropDown();
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.userid = HttpContext.Session.GetString("Id");
            DropDown();
            var advert = _advertService.GetById(id);
            return View(advert);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Advert advert)
        {
            AdvertValidation validationRules = new AdvertValidation();
            ValidationResult result = validationRules.Validate(advert);

            if (result.IsValid)
            {
                _advertService.Update(advert);
                TempData["Update"] = "İlan Güncelleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            DropDown();
            return View(advert);
        }




        public IActionResult Delete(int id)
        {
            var sessionUser = HttpContext.Session.GetString("Id");
            var delete = _advertService.GetById(id);
            if (sessionUser.ToString() == delete.UserAdminId)
            {
                _advertService.Delete(delete);
                return RedirectToAction("Index");
            }
            return View();

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
            ViewBag.cityList = new SelectList(CityGet(), "CityId", "CityName");
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