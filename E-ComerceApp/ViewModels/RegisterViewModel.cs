using System.ComponentModel.DataAnnotations;

namespace E_ComerceApp.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
