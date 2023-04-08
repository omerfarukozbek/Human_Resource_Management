using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Enums
{
    public enum Graduation
    {
        [Display(Name = "Lütfen seçim yapın")]
        None = 0,
        [Display(Name = "Lisans")]
        Undergrad,
        [Display(Name = "Yüksek Lisans")]
        Masters,
        [Display(Name = "Doktora")]
        PhD
    }
}