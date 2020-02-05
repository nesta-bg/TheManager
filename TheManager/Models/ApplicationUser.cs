using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheManager.Models
{
    //IdentityUser SHIFT+F12 = Find All References
    //CTRL+SHIFT+F = Find And Replace
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
