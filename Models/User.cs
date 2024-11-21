using Microsoft.AspNetCore.Identity;

namespace JobBoardWebApi.Models
{
    public class User : IdentityUser
    {
        public ICollection<Application> Applications { get; set; }
    }
}
