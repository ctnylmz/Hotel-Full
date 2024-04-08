using Microsoft.AspNetCore.Identity;

namespace WebApp.Areas.Admin.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }

    }
}
