using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class SignUpModel
    {
        [Required]
        [Display(Name = "EmailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConformPassword")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "ConformPassword")]
        [DataType(DataType.Password)]
        public string ConformPassword { get; set; }
    }
}
