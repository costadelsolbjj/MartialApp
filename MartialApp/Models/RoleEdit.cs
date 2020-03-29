using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MartialApp.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityUser> Members { get; set; }
        public IEnumerable<IdentityUser> NonMembers { get; set; }
    }
}