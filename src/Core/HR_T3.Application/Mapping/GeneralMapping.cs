using AutoMapper;
using HR_T3.Application.ViewModels;
using HR_T3.Domain.Entities;

namespace HR_T3.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Person, CompanyManagerSummaryVM>().ReverseMap();
            CreateMap<Person, EmployeeAddVM>().ReverseMap();
            CreateMap<Person, EmployeeListVM>().ReverseMap();
            CreateMap<Person, EmployeeEditVM>()
                .ForMember(x => x.Photo, opt => opt.Ignore())
                .ForMember(x => x.PhotoPath, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<EmployeeEditVM, Person>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(y => y.PhotoPath));
            CreateMap<EmployeeDetailVM, Person>().ReverseMap();
            CreateMap<Person, PersonLoginVM>().ReverseMap();
            CreateMap<Person, PersonUpdateVM>().ReverseMap();
            CreateMap<Person, EmployeeSummaryVM>().ReverseMap();
        }
    }
}
