using HR_T3.Application.Validations;
using HR_T3.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HR_T3.Application.ViewModels
{
    public class EmployeeEditVM
    {
        [Display(Name = "Personel Tc Kimlik No:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        [MaxLength(11, ErrorMessage = "TC Kimlik No 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "TC Kimlik No 11 haneli olmalıdır")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Sadece harf girişi yapınız")]
        public string Id { get; set; }

        [Display(Name = "İsim:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        [MaxLength(30, ErrorMessage = "Maximum 30 kararkter girebilirsiniz"), MinLength(2, ErrorMessage = "Minimum 2 kararkter girebilirsiniz")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum 30 kararkter girebilirsiniz")]
        [Display(Name = "İkinci İsim:")]
        public string? MiddleName { get; set; }

        [Display(Name = "2.Soy İsim:")]
        [MaxLength(30, ErrorMessage = "Maximum 30 kararkter girebilirsiniz")]
        public string? LastSurName { get; set; }

        [Display(Name = "Soyisim:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        [MaxLength(30, ErrorMessage = "Maximum 30 kararkter girebilirsiniz"), MinLength(2, ErrorMessage = "Minimum 2 kararkter girebilirsiniz")]
        public string Surname { get; set; }

        [Display(Name = "Cinsiyet:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public string Gender { get; set; }

        [Display(Name = "Fotoğraf:")]
        [PhotoValidation]
        public IFormFile? Photo { get; set; }
        public string? PhotoPath { get; set; }

        [Display(Name = "Doğum günü:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Telefon No:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        [RegularExpression(@"^(05(\d{9}))$", ErrorMessage = "Telefon numarası '05' ile başlamalıdır")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail:")]
        [EmailValidation(ErrorMessage = "Mail uygun formatta değil")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public string Email { get; set; }

        [Display(Name = "Adres:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public string Address { get; set; }

        [Display(Name = "Mezuniyet:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public Graduation Graduation { get; set; }

        [Display(Name = "Ünvan:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public string Title { get; set; }  //Enum olabilir

        [Display(Name = "Departman:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public string Department { get; set; }

        [Display(Name = "İşe başlama tarihi:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public DateTime StartDateOfWork { get; set; }

        [Display(Name = "Yıllık izin:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        [Range(0, 30, ErrorMessage = "İzin gün sayısı 0-30 arasında olmalıdır")]
        public int AnnualPermit { get; set; }

        [Display(Name = "Maaş:")]
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur")]
        public double Salary { get; set; }

        [Display(Name = "Aktiflik")]
        [Required(ErrorMessage = "Bu alanın seçilmesi zorunludur")]
        public bool IsActive { get; set; }
    }
}