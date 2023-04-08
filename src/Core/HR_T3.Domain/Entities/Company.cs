using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Entities
{
    public class Company : BaseEntity
    {
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }

        public ICollection<Person> Employees { get; set; }
    }
}
