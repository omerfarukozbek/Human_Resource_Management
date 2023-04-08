using HR_T3.Application.Validations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HR_T3.Application.ViewModels
{
    public class PersonUpdateVM
    {
        public string Id { get; set; }

        [DataType(DataType.Upload)]
        [PhotoValidation(ErrorMessage = "Secilen uzantı desteklenmiyor. Lütfen  '.jpeg' yada '.png' uzantılı dosyalar seçiniz.")]
        public IFormFile? Photo { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = "Telefon No:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        [RegularExpression(@"^(05(\d{9}))$", ErrorMessage = "Telefon numarası '05' ile başlamalıdır")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

       
      
    }
}
