using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Components.Contact
{
    public class _ContactNavPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
