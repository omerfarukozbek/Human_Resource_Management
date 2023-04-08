using System.ComponentModel.DataAnnotations;

namespace HR_T3.Application.Validations
{
    public class BirthDateRange : RangeAttribute
    {
        public BirthDateRange()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-18).ToShortDateString(),
                  DateTime.Now.ToShortDateString())
        { }
    }
}
