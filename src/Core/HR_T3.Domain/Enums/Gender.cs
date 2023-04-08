using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Lütfen seçim yapın")]
        None = 0,
        [Display(Name = "Erkek")]
        Male,
        [Display(Name = "Kadın")]
        Female
    }
}
