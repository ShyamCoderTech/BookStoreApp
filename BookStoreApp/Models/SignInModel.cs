using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class SignInModel
    {
        [Required]
        [Display (Name = "EmailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

    }
}
