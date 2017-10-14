using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace bc.cores.models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
