using System.ComponentModel.DataAnnotations;

namespace bc.modules.account.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
