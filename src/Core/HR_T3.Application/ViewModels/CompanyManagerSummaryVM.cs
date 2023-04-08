namespace HR_T3.Application.ViewModels
{
    public class CompanyManagerSummaryVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? LastSurName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            string fullName = Name;
            if (!string.IsNullOrEmpty(MiddleName))
            {
                fullName += " " + MiddleName;
            }
            fullName += " " + Surname.ToUpper();
            if (!string.IsNullOrEmpty(LastSurName))
            {
                fullName += " " + LastSurName.ToUpper();
            }
            return fullName;
        }
    }
}
