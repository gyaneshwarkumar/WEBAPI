using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Token.WebApiCore.Server.Models
{
    public class MyRole : IdentityRole
    {
        public string Description { get; set; }
    }
}