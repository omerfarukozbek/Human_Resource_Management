using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Enums
{
    public enum Title
    {
        [Display(Name = "Lütfen seçim yapın")]
        None = 0,
        [Display(Name = "Proje Yöneticisi")]
        ProjectManager,
        [Display(Name = "Grup Şefi")]
        GroupChief,
        [Display(Name = "Çalışan")]
        Employee
    }
}