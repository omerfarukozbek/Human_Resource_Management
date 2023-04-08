using AutoMapper;
using HR_T3.Application.Helpers;
using HR_T3.Application.ViewModels;
using HR_T3.Context.Persistence;
using HR_T3.Domain.Entities;
using HR_T3.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HR_T3.Persistence.Repositories
{
    public class PersonRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public PersonRepository(AppDbContext dbContext, UserManager<Person> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<string> Insert(EmployeeAddVM employeeAddVM, ClaimsPrincipal projectManager)
        {
            try
            {
                if (_dbContext.Persons.Any(x => x.Id == employeeAddVM.Id))
                {
                    return "MultipleID";
                }
                if (_dbContext.Persons.Any(x => x.Email == employeeAddVM.Email))
                {
                    return "MultipleEMAIL";
                }
                if (!StringHelpers.IsValidIdentityNumber(employeeAddVM.Id)){
                    return "InvalidID";
                }
                Person newPerson = new()
                {
                    Id = employeeAddVM.Id,
                    Name = employeeAddVM.Name,
                    MiddleName = employeeAddVM.MiddleName,
                    Surname = employeeAddVM.Surname,
                    LastSurName = employeeAddVM.LastSurName,
                    UserName = employeeAddVM.Email.Split("@")[0],
                    Email = employeeAddVM.Email,
                    Birthday = employeeAddVM.Birthday,
                    StartDateOfWork = employeeAddVM.StartDateOfWork,
                    Department = employeeAddVM.Department,
                    Title = employeeAddVM.Title,
                    PhoneNumber = employeeAddVM.PhoneNumber,
                    Address = employeeAddVM.Address,
                    AnnualPermit = employeeAddVM.AnnualPermit,
                    Salary = employeeAddVM.Salary,
                    Graduation = employeeAddVM.Graduation,
                    IsActive = employeeAddVM.IsActive
                };
                var id = _userManager.GetUserId(projectManager);
                var user = _dbContext.Persons.FirstOrDefault(x => x.Id == id);
                newPerson.CompanyId = user.CompanyId;

                if (employeeAddVM.Gender == "Male")
                    newPerson.Gender = Gender.Male;
                else
                    newPerson.Gender = Gender.Female;

                if (employeeAddVM.Photo != null)
                {
                    var extension = Path.GetExtension(employeeAddVM.Photo.FileName);

                    var imageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/PersonImages", imageName);
                    var stream = new FileStream(location, FileMode.Create);
                    employeeAddVM.Photo.CopyTo(stream);
                    newPerson.Photo = "assets/images/PersonImages/" + imageName;
                }
                await _dbContext.Persons.AddAsync(newPerson);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    await _dbContext.UserRoles.AddAsync(
                         new IdentityUserRole<string>
                         {
                             UserId = newPerson.Id,
                             RoleId = "employee"
                         });
                    return "OK";
                }
                else
                {
                    return "ERROR";
                }
            }
            catch
            {
                return "ERROR";
            }

        }

        public async Task<bool> Update(PersonUpdateVM personUpdateVM)
        {
            try
            {
                Person UpdatePerson = _dbContext.Persons.Find(personUpdateVM.Id);
                if (personUpdateVM.Photo != null)
                {
                    var extension = Path.GetExtension(personUpdateVM.Photo.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/PersonImages", imageName);
                    var stream = new FileStream(location, FileMode.Create);
                    personUpdateVM.Photo.CopyTo(stream);
                    UpdatePerson.Photo = "assets/images/PersonImages/" + imageName;
                }
                UpdatePerson.Address = personUpdateVM.Address;
                UpdatePerson.PhoneNumber = personUpdateVM.PhoneNumber;
                _dbContext.Persons.Update(UpdatePerson);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeEditVM employeeEditVM)
        {
            try
            {
                var findEmployee = await _dbContext.Persons.FindAsync(employeeEditVM.Id);
                if (findEmployee == null)
                    return false;
                if (employeeEditVM.Photo != null)
                {
                    var extension = Path.GetExtension(employeeEditVM.Photo.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/PersonImages", imageName);
                    var stream = new FileStream(location, FileMode.Create);
                    employeeEditVM.Photo.CopyTo(stream);
                    employeeEditVM.PhotoPath = "assets/images/PersonImages/" + imageName;
                }
                _mapper.Map(employeeEditVM, findEmployee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PersonUpdateVM> GetByIdForUpdate(string id)
        {
            Person UpdatedPerson = await _dbContext.Persons.FindAsync(id);
            return _mapper.Map<PersonUpdateVM>(UpdatedPerson);
            //PersonUpdateVM personelVM = new();
            //if (UpdatedPerson != null)
            //{
            //    personelVM.Id = UpdatedPerson.Id;
            //    personelVM.Address = UpdatedPerson.Address;
            //    personelVM.PhoneNumber = UpdatedPerson.PhoneNumber;
            //}
            //return personelVM;
        }

        public async Task<EmployeeEditVM> GetByIdForEdit(string id)
        {
            Person findPerson = await _dbContext.Persons.FirstAsync(x => x.Id == id);
            EmployeeEditVM employeeEditVM = _mapper.Map<EmployeeEditVM>(findPerson);
            employeeEditVM.PhotoPath = findPerson.Photo;
            return employeeEditVM;
        }

        public List<EmployeeListVM> GetList(int page, ClaimsPrincipal projectManager, out int maxPage)
        {
            maxPage = 0;
            var id = _userManager.GetUserId(projectManager);
            var getCompany = _dbContext.Persons.Find(id);
            //var getPersons = _dbContext.Persons.Where(x => x.CompanyId == getCompany.CompanyId).Skip(2 * page);
            var getPersons = _dbContext.Persons.Where(x => x.CompanyId == getCompany.CompanyId);
            if (getPersons == null) return null;
            //page++;
            //maxPage = (int)Math.Ceiling((double)getPersons.Count() / 2);
            //return getPersons.Take(2).Select(x => new EmployeeListVM(x.Id, x.Photo, x.Name, x.Surname, x.PhoneNumber, x.Email, x.IsActive)).ToList();
            return getPersons.Select(x => new EmployeeListVM(x.Id, x.Photo, x.Name, x.Surname, x.PhoneNumber, x.Email, x.IsActive)).ToList();
        }

        public CompanyManagerSummaryVM GetSummary(ClaimsPrincipal projectManager)
        {
            var id = _userManager.GetUserId(projectManager);
            var companyManger = _dbContext.Persons.Find(id);
            return _mapper.Map<CompanyManagerSummaryVM>(companyManger);

            //return new()
            //{
            //    Id = companyManger.Id,
            //    Name = companyManger.Name,
            //    Surname = companyManger.Surname,
            //    MiddleName = companyManger.MiddleName,
            //    LastSurName = companyManger.LastSurName,
            //    Photo = companyManger.Photo,
            //    Title = companyManger.Title,
            //    Email = companyManger.Email,
            //    PhoneNumber = companyManger.PhoneNumber,
            //    Address = companyManger.Address,
            //    Department = companyManger.Department
            //};
        }
        public EmployeeSummaryVM GetSummaryEmployee(ClaimsPrincipal employee)
        {
            var id = _userManager.GetUserId(employee);
            var companyManger = _dbContext.Persons.Find(id);
            return _mapper.Map<EmployeeSummaryVM>(companyManger);

            //return new()
            //{
            //    Id = companyManger.Id,
            //    Name = companyManger.Name,
            //    Surname = companyManger.Surname,
            //    MiddleName = companyManger.MiddleName,
            //    LastSurName = companyManger.LastSurName,
            //    Photo = companyManger.Photo,
            //    Title = companyManger.Title,
            //    Email = companyManger.Email,
            //    PhoneNumber = companyManger.PhoneNumber,
            //    Address = companyManger.Address,
            //    Department = companyManger.Department
            //};
        }

        public EmployeeDetailVM GetEmployeeDetail(string id)
        {
            Person personDetails = _dbContext.Persons.Find(id);
            return _mapper.Map<EmployeeDetailVM>(personDetails);
            //EmployeeDetailVM employeeDetailVM = new EmployeeDetailVM();
            //if (personDetails != null)
            //{
            //    employeeDetailVM.Id = personDetails.Id;
            //    employeeDetailVM.Salary = personDetails.Salary;
            //    employeeDetailVM.Surname = personDetails.Surname;
            //    employeeDetailVM.LastSurName = personDetails.LastSurName;
            //    employeeDetailVM.MiddleName = personDetails.MiddleName;
            //    employeeDetailVM.Address = personDetails.Address;
            //    employeeDetailVM.AnnualPermit = personDetails.AnnualPermit;
            //    employeeDetailVM.Email = personDetails.Email;
            //    employeeDetailVM.Birthday = personDetails.Birthday.ToShortDateString();
            //    employeeDetailVM.Graduation = personDetails.Graduation;
            //    employeeDetailVM.StartDateOfWork = personDetails.StartDateOfWork.ToShortDateString();
            //    employeeDetailVM.Title = personDetails.Title;
            //    employeeDetailVM.Photo = personDetails.Photo;
            //    employeeDetailVM.Name = personDetails.Name;
            //    employeeDetailVM.Department = personDetails.Department;
            //    employeeDetailVM.PhoneNumber = personDetails.PhoneNumber;
            //}
            //return employeeDetailVM;
        }
    }
}
