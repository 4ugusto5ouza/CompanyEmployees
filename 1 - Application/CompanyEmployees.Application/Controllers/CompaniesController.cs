using CompanyEmployees.Application.ModelBinders;
using CompanyEmployees.Service.DataTransferObjects.Companies;
using CompanyEmployees.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _serviceManager.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("collection/({ids})", Name = "GetCompanyCollection")]
        public async Task<IActionResult> GetCompanyColletion([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _serviceManager.CompanyService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _serviceManager.CompanyService.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto object is null");


            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdCompany = await _serviceManager.CompanyService.CreateCompanyAsync(company);

            return CreatedAtRoute("GetCompany", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _serviceManager.CompanyService.CreateCompanyCollectionAsync(companyCollection);

            return CreatedAtRoute("GetCompanyCollection", new { result.ids }, result.companies);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company is null)
                return BadRequest("CompanyForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);


            await _serviceManager.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id, bool trackChanges)
        {
            await _serviceManager.CompanyService.DeleteCompanyAsync(id, trackChanges);

            return NoContent();
        }
    }
}
