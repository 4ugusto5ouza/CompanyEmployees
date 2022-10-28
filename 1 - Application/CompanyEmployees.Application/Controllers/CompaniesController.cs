using CompanyEmployees.Application.ActionFilters;
using CompanyEmployees.Application.ModelBinders;
using CompanyEmployees.Domain.RequestFeatures.Parameters;
using CompanyEmployees.Service.DataTransferObjects.Companies;
using CompanyEmployees.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyEmployees.Application.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CompaniesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");

            return Ok();
        }

        [HttpGet(Name = "GetCompanies")]
        [HttpHead]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            var pagedResult = await _serviceManager.Company.GetAllCompaniesAsync(companyParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.companies);
        }

        [HttpGet("collection/({ids})", Name = "GetCompanyCollection")]
        public async Task<IActionResult> GetCompanyColletion([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _serviceManager.Company.GetByIdsAsync(ids, trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _serviceManager.Company.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            var createdCompany = await _serviceManager.Company.CreateCompanyAsync(company);

            return CreatedAtRoute("GetCompany", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _serviceManager.Company.CreateCompanyCollectionAsync(companyCollection);

            return CreatedAtRoute("GetCompanyCollection", new { result.ids }, result.companies);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            await _serviceManager.Company.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id, bool trackChanges)
        {
            await _serviceManager.Company.DeleteCompanyAsync(id, trackChanges);

            return NoContent();
        }
    }
}
