using HR_T3.Domain.Enums;

namespace HR_T3.Domain.Entities
{
    public class Cost : BaseEntity
    {
        public TypeOfCost TypeOfCost { get; set; }
        public double Damage { get; set; }
        public DateTime ResponseDate { get; set; }
        public DateTime? ReplyDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public string? File { get; set; }

        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}
