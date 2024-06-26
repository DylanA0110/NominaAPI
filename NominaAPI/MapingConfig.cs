using AutoMapper;
using SharedModels.Dto;
using SharedModels.Entidades;
using SharedModels.Entities;

namespace PayrollAPI
{
    public class MapingConfig : Profile
    {
        public MapingConfig()
        {
            CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Income, IncomeCreateDTO>().ReverseMap();
            CreateMap<Income, IncomeUpdateDTO>().ReverseMap();
            CreateMap<Deduction, DeductionDTO>().ReverseMap();
            CreateMap<Deduction, DeductionCreateDTO>().ReverseMap();
            CreateMap<Deduction, DeductionUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDTO>().ReverseMap();
            CreateMap<Payroll, PayrollDTO>().ReverseMap();
            CreateMap<Payroll, PayrollCreateDTO>().ReverseMap();
            CreateMap<Payroll, PayrollUpdateDTO>().ReverseMap();
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<EmployeeCreateDTO, Employee>()
              .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<EmployeeUpdateDTO, Employee>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));
        }
    }
}
