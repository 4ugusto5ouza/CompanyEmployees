﻿using AutoMapper;
using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Service.DataTransferObjects.Companies;
using CompanyEmployees.Service.DataTransferObjects.Employees;

namespace CompanyEmployees.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress, 
                    opt => opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<CompanyForUpdateDto, Company>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }
    }
}
