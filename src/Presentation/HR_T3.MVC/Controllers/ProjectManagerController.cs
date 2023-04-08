using AutoMapper;
using HR_T3.Application.Helpers;
using HR_T3.Application.ViewModels;
using HR_T3.Domain.Entities;
using HR_T3.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HR_T3.MVC.Controllers
{
    [Authorize(Roles = "Project Manager")]
    public class ProjectManagerController : Controller
    {

        private readonly PersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ProjectManagerController(PersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var cmsVM = _personRepository.GetSummary(HttpContext.User);
            return View(cmsVM);
        }

        public async Task<IActionResult> UpdatePerson(string id)
        {
            PersonUpdateVM personelVM = await _personRepository.GetByIdForUpdate(id);
            return View(personelVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(PersonUpdateVM personVM)
        {
            if (ModelState.IsValid)
            {
                if (await _personRepository.Update(personVM))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(null, "Bilinmeyen bir hata oluştu.");
                }
            }
            return View(personVM);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeAddVM newEmployee)
        {
            ModelState.Remove("MiddleName");
            ModelState.Remove("LastSurName");
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                string eklemeSonucu = await _personRepository.Insert(newEmployee, HttpContext.User);
                if (eklemeSonucu == "MultipleID")
                {
                    ModelState.AddModelError("Id", "Bu TC numarası daha önce kayıt edilmiş.");
                    return View(newEmployee);
                }
                else if (eklemeSonucu == "MultipleEMAIL")
                {
                    ModelState.AddModelError("Email", "Bu email adresi zaten kayıt edilmiş.");
                    return View(newEmployee);
                }
                else if (eklemeSonucu == "InvalidId")
                {
                    ModelState.AddModelError("Id", "Girilen TC numarası yanlış.");
                    return View(newEmployee);
                }
                else if (eklemeSonucu == "OK")
                {
                    var body = new StringBuilder();

                    body.AppendLine("Şifreniz :" + StringHelpers.CreatePassword(10));
                    body.AppendLine("Ad & Soyad: " + newEmployee.Name + " " + newEmployee.Surname);
                    body.AppendLine("E-Mail Adresi: " + newEmployee.Email);
                    MailHelper.MailSender(body.ToString(), newEmployee.Email);
                    return RedirectToAction("ListEmployee", "ProjectManager");
                }
                ModelState.AddModelError(null, "Bilinmeyen bir hata oluştu.");
                return View(newEmployee);
            }
            return View(newEmployee);
        }

        [HttpGet("ProjectManager/ListEmployee/{page?}")]
        public async Task<IActionResult> ListEmployee(int page = 1)
        {
            if (page == 0) page = 1;
            var personListVM = _personRepository.GetList(page, HttpContext.User, out int maxPage);
            TempData["maxPage"] = maxPage;
            return View(personListVM);
        }

        public IActionResult DetailEmployee(string id)
        {
            var employeeDetailVM = _personRepository.GetEmployeeDetail(id);
            if (employeeDetailVM == null)
                return RedirectToAction("Index");
            else
                return View(employeeDetailVM);
        }

        public async Task<IActionResult> EditEmployee(string id)
        {
            var findEmployee = await _personRepository.GetByIdForEdit(id);
            if (findEmployee == null)
                return RedirectToAction("Index");
            else
                return View(findEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeEditVM employeeEditVM)
        {
            if (ModelState.IsValid)
            {
                var findEmployee = await _personRepository.GetByIdForEdit(employeeEditVM.Id);
                if (findEmployee == null)
                {
                    ModelState.AddModelError(null, "Bilinmeyen bir hata oluştu");
                    return View(employeeEditVM);
                }
                else
                {
                    if (await _personRepository.UpdateEmployee(employeeEditVM))
                    {
                        return RedirectToAction("ListEmployee");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bilinmeyen bir hata oluştu");
                        return View(employeeEditVM);
                    }
                }
            }
            return View(employeeEditVM);
        }
    }
}