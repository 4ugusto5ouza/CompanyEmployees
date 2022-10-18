using System;

namespace CompanyEmployees.Service.DataTransferObjects
{
    public  record CompanyDto(Guid Id, string Name, string FullAddress);
}
