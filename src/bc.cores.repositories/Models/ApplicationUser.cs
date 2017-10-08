using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.repositories.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
