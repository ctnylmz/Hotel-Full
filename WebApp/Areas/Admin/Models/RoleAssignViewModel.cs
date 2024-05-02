using Microsoft.AspNetCore.Identity;

namespace WebApp.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public string UserId { get; set; } 
        public string RoleId { get; set; } 
        public string RoleName { get; set; } 
        public bool RoleExist { get; set; } 
    }

}
