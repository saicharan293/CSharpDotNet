using Microsoft.AspNetCore.Identity;

namespace TaskFlowProject.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string RoleName { get; set; }
    }
}
