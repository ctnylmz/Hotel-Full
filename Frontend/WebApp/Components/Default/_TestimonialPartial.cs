using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
