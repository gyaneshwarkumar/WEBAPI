using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthenticationServer.Models
{
    public class MyRole : IdentityRole
    {
        public string Description { get; set; }
    }
}