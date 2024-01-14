using E_State.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.ViewComponents
{
    public class AdvertSlider : ViewComponent
    {
        IImagesService _imagesService;

        public AdvertSlider(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        public IViewComponentResult Invoke()
        {
            var list = _imagesService.List(x => x.Status == true);
            return View(list);
        }
    }
}
