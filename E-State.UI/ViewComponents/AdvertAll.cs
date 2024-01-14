using E_State.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.ViewComponents
{
    public class AdvertAll : ViewComponent
    {
        IImagesService _imagesService;
        IAdvertService _advertService;

        public AdvertAll(IImagesService imagesService, IAdvertService advertService)
        {
            _imagesService = imagesService;
            _advertService = advertService;
        }

        public IViewComponentResult Invoke()
        {
            var list = _advertService.List(x => x.Status == true);
            var images = _imagesService.List(x => x.Status == true);
            ViewBag.images = images;
            return View(list);
        }
    }
}
