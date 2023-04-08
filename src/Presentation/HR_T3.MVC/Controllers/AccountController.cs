using HR_T3.Application.Helpers;
using HR_T3.Application.ViewModels;
using HR_T3.Context.Persistence;
using HR_T3.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_T3.MVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<Person> _signInManager;
        private readonly UserManager<Person> _userManager;
        private readonly AppDbContext _appDbContext;

        public AccountController(SignInManager<Person> signInManager, UserManager<Person> userManager, AppDbContext appDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(PersonLoginVM personLoginVM)
        {
            if (ModelState.IsValid)
            {
                var user = _signInManager.UserManager.Users.Where(u => u.Email == personLoginVM.Email).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Hatalı giriş yaptınız!");
                    return View(personLoginVM);
                }
                var result = await _signInManager.PasswordSignInAsync(
                    user.UserName,
                    personLoginVM.Password,
                    personLoginVM.RememberMe,
                    lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (!result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Birden çok kez hatalı giriş yaptınız! Bir süre bekleyin.");
                    return View(personLoginVM);
                }
            }
            return View(personLoginVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var logginedUser = await _userManager.GetUserAsync(User);
            PersonUpdateVM personUpdateVM = new()
            {
                Id = logginedUser.Id,
                Address = logginedUser.Address,
                PhoneNumber = logginedUser.PhoneNumber,
            };
            return View(personUpdateVM);
        }

        [HttpPost]
        public IActionResult Update(PersonUpdateVM personVM)
        {
            if (ModelState.IsValid)
            {
                Person UpdatePerson = _appDbContext.Persons.Find(personVM.Id);
                if (personVM.Photo != null)
                {
                    var extension = Path.GetExtension(personVM.Photo.FileName);
                    if (!ImageHelper.HasImageExtension(extension))
                    {
                        ModelState.AddModelError("Photo", "Sadece png, jpg ve jpeg formatı kabul edilmektedir.");
                        return View(personVM);
                    }
                    var imageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/PersonImages", imageName);
                    var stream = new FileStream(location, FileMode.Create);
                    personVM.Photo.CopyTo(stream);
                    UpdatePerson.Photo = "assets/images/PersonImages/" + imageName;

                }
                UpdatePerson.Address = personVM.Address;
                UpdatePerson.PhoneNumber = personVM.PhoneNumber;
                _appDbContext.Persons.Update(UpdatePerson);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(personVM);
            }
        }

        public IActionResult Detail(string id)
        {
            Person personDetails = _appDbContext.Persons.Find(id);
            EmployeeDetailVM personelDetailVM = new EmployeeDetailVM();

            if (personDetails != null)
            {
                personelDetailVM.Id = personDetails.Id;
                personelDetailVM.Salary = personDetails.Salary;
                personelDetailVM.Surname = personDetails.Surname;
                personelDetailVM.LastSurName = personDetails.LastSurName;
                personelDetailVM.MiddleName = personDetails.MiddleName;
                personelDetailVM.Address = personDetails.Address;
                personelDetailVM.AnnualPermit = personDetails.AnnualPermit;
                personelDetailVM.Email = personDetails.Email;
                personelDetailVM.Birthday = personDetails.Birthday;
                personelDetailVM.Graduation = personDetails.Graduation;
                personelDetailVM.StartDateOfWork = personDetails.StartDateOfWork;
                personelDetailVM.Title = personDetails.Title;
                personelDetailVM.Photo = personDetails.Photo;
                personelDetailVM.Name = personDetails.Name;
                personelDetailVM.Department = personDetails.Department;
                personelDetailVM.PhoneNumber = personDetails.PhoneNumber;
                return View(personelDetailVM);
            }
            return RedirectToAction("Index");
        }
    }
}
