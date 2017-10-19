using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace bc.cores.models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }

        [JsonIgnore]
        [Required]
        public override string PasswordHash { get; set; }

        [JsonIgnore]
        [Required]
        [MaxLength(100)]
        public override string SecurityStamp { get; set; }

        [JsonIgnore]
        [Required]
        [MaxLength(100)]
        public override string ConcurrencyStamp { get; set; }

        [MaxLength(256)]
        public override string PhoneNumber { get; set; }
    }
}
