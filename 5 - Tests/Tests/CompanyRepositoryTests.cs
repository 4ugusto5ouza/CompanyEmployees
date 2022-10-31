using CompanyEmployees.Domain.Entities;
using CompanyEmployees.Domain.Interfaces.Repositories;
using CompanyEmployees.Domain.RequestFeatures;
using CompanyEmployees.Domain.RequestFeatures.Parameters;
using Moq;

namespace Tests
{
    public class CompanyRepositoryTests
    {
        [Fact]
        public void GetAllCompaniesAsync_ReturnsListOfCompanies_WithASingleCompany()
        {
            //Arrange
            var mockRepo = new Mock<ICompanyRepository>();

            var id = Guid.NewGuid();
            mockRepo.Setup(repo => (
                repo.GetAllCompaniesAsync(false)
            )).Returns(Task.FromResult(GetCompanies()));

            //Act
            var result = mockRepo.Object.GetAllCompaniesAsync(false)
                                        .GetAwaiter()
                                        .GetResult()
                                        .ToList();

            // Assert
            Assert.IsType<List<Company>>(result);
            Assert.Single(result);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return new List<Company>
            {
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Company",
                    Country = "United States",
                    Address = "908 Woodrow Way"
                }
            };
        }
    }

}