using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WalkFido.Models
{
    public class AppUser: IdentityUser
    {
        //properties that the walker and owner has in common

        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Image { get; set; }

        public string Owner { get; set; }








    }
}
