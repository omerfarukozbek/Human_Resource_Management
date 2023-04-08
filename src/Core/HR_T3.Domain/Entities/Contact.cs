using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Entities
{
    public class Contact : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Subject { get; set; }
        [MaxLength(200)]
        public string Message { get; set; }
    }
}
