using AutoMapper;
using HR_T3.Context.Persistence;
using HR_T3.Domain.Entities;
using HR_T3.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_T3.MVC.Controllers
{
    [Authorize(Roles = "Employee")]

    public class EmployeeController : Controller
    {
        private readonly PersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public EmployeeController(PersonRepository personRepository, IMapper mapper, AppDbContext appDbContext)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var EmpSmry = _personRepository.GetSummaryEmployee(HttpContext.User);
            return View(EmpSmry);
        }
        public IActionResult CostList()
        {
            List<Cost> costs = _appDbContext.Costs.ToList();
         
            return View(costs);
        }
    }
}
