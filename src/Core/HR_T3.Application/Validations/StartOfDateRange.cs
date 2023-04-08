using System.ComponentModel.DataAnnotations;

namespace HR_T3.Application.Validations
{
    public class StartOfDateRange : RangeAttribute
    {
        public StartOfDateRange()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-2).ToShortDateString(),
                  DateTime.Now.AddYears(1).ToShortDateString())
        { }
    }
}
