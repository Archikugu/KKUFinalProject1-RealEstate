using E_State.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.Controllers
{
    public class AdvertController : Controller
    {
        IImagesService _imagesService;
        IAdvertService _advertService;

        public AdvertController(IImagesService imagesService, IAdvertService advertService)
        {
            _imagesService = imagesService;
            _advertService = advertService;
        }

        public IActionResult Details(int id)
        {
            var detail = _advertService.GetById(id);
            var img = _imagesService.List(x => x.AdvertId == id);
            ViewBag.images = img;
            return View(detail);
        }
        public IActionResult AdvertRent()
        {
            var rent = _advertService.List(x => x.Type.Situation.SituationName == "Kiralık");
            var images = _imagesService.List(x => x.Status == true);
            ViewBag.images = images;
            return View(rent);
        }
        public IActionResult AdvertSale()
        {
            var rent = _advertService.List(x => x.Type.Situation.SituationName == "Satılık");
            var images = _imagesService.List(x => x.Status == true);
            ViewBag.images = images;
            return View(rent);
        }
    }
}
