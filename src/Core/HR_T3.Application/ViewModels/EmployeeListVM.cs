namespace HR_T3.Application.ViewModels
{
    public class EmployeeListVM
    {
        public string Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public EmployeeListVM(string id, string photo, string name, string surname, string phoneNumber, string email, bool isActive)
        {
            Id = id;
            Photo = photo;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            IsActive = isActive;
        }
    }
}
