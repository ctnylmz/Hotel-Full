using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Default
{
    public class _BookingStartPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
   
}
