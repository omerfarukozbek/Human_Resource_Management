using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Enums
{
    public enum Department
    {
        [Display(Name = "Lütfen seçim yapın")]
        None = 0,
        [Display(Name = "BT")]
        BT,
        [Display(Name = "İnsan Kaynakları")]
        HumanResources,
        [Display(Name = "Yazılım")]
        Software,
        [Display(Name = "AR-GE")]
        ReDev,
        [Display(Name = "İdari")]
        Administrative,
        [Display(Name = "Satış")]
        Seller
    }
}
