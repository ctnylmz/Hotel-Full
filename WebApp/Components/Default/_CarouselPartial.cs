using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Default
{
    public class _CarouselPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }

}
