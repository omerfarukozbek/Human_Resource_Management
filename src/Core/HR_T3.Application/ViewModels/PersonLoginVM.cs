using System.ComponentModel.DataAnnotations;

namespace HR_T3.Application.ViewModels
{
    public class PersonLoginVM
    {
        [Required(ErrorMessage = "Email adresi girilmesi zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
