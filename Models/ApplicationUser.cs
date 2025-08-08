using Microsoft.AspNetCore.Identity;

namespace HelpDesk_Benedict.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool AdminConfirmed { get; set; } = false;
    }
}
