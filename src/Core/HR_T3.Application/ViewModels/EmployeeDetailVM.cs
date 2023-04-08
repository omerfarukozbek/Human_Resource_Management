using HR_T3.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace HR_T3.Application.ViewModels
{
    public class EmployeeDetailVM
    {

        [Display(Name = "Personel Tc No")]
        public string Id { get; set; }
        [Display(Name = "İsim")]
        public string Name { get; set; }
        [Display(Name = "2.İsim")]
        public string MiddleName { get; set; }
        [Display(Name = "2.Soyisim")]
        public string LastSurName { get; set; }
        [Display(Name = "Soyisim")]
        public string Surname { get; set; }
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
        [Display(Name = "Doğum Günü")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Telefon No")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Mezuniyet")]
        public Graduation Graduation { get; set; }
        [Display(Name = "Ünvan")]
        public Title Title { get; set; }
        [Display(Name = "Departman")]
        public Department Department { get; set; }
        [Display(Name = "İşe Başlama Tarihi")]
        public DateTime StartDateOfWork { get; set; }
        [Display(Name = "Yıllık İzin")]
        public int AnnualPermit { get; set; }
        [Display(Name = "Maaş")]
        public double Salary { get; set; }

        public override string ToString()
        {
            string fullName = Name;
            if (!string.IsNullOrEmpty(MiddleName))
            {
                fullName += " " + MiddleName;
            }
            fullName += " " + Surname.ToUpper();
            if (!string.IsNullOrEmpty(LastSurName))
            {
                fullName += " " + LastSurName.ToUpper();
            }
            return fullName;
        }
    }
}
