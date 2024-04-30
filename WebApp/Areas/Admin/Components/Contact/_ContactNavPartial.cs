using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Components.Contact
{
    public class _DashboasrdHeadPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
