using Microsoft.AspNetCore.Identity;

namespace ITI_Final_Poject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }

    }
}
