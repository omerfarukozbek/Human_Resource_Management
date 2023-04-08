using HR_T3.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HR_T3.Domain.Entities
{
    public class Person : IdentityUser<string>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public string TcNo { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Surname { get; set; }
        [MaxLength(10)]
        public string? MiddleName { get; set; }
        [MaxLength(10)]
        public string? LastSurName { get; set; }
        public string? Photo { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public Graduation Graduation { get; set; } = Graduation.None;
        public Title Title { get; set; } = Title.None;
        public Department Department { get; set; } = Department.None;
        public DateTime StartDateOfWork { get; set; }
        public int AnnualPermit { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public List<Cost> Costs { get; set; }

        public Person()
        {
            Costs = new List<Cost>();
        }
    }
}