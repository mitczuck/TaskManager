using TaskManager.Application.Implementations;
using TaskManager.Infrastructure.Interfaces;
using Moq;

public class CalculateServiceTests
{
    private readonly Mock<IProjectRepository> _companyRepositoryMock;
    //private readonly Mock<INexLogService> _nexLogServiceMock;
    private readonly ProjectService _calculateService;

    public CalculateServiceTests()
    {
        _companyRepositoryMock = new Mock<IProjectRepository>();
        //_nexLogServiceMock = new Mock<INexLogService>();

        //_calculateService = new ProjectService(
            //_companyRepositoryMock.Object,
            //_nexLogServiceMock.Object
        //);
    }

    //[Fact]
    //public void Calculate_ShouldReturnSuccessResponse_WhenCalculationIsSuccessful()
    //{
    //    // Arrange: configura o repositório e serviços externos para retornar valores simulados.
    //    var calculateRequest = new CalculateRequest
    //    {
    //        Items = new List<CalculateItem> { new CalculateItem { Weight = 1 } },
    //        Zipcode = "12345678",
    //        Amount = 100
    //    };

    //    string appToken = "abc1234def5678ghijk";
    //    string appKey = "XYZ9876LMNOPQRS";

    //    var company = new Company
    //    {
    //        SenderDocument = "12345678901",
    //        OriginPointCode = "ORG",
    //        OriginPostalCode = "12345678",
    //        InsuranceType = 1
    //    };

    //    var tokenResponse = new TokenResponse
    //    {
    //        SessionToken = "621939022a3941cd96cb4459b7c150f0",
    //        SessionId = "8264921"
    //    };

    //    var customerToken = new Document
    //    {
    //        Token = "5FDFB660D7CF4FFE9592F56562573289"
    //    };

    //    var quotationResponse = new QuotationResponse
    //    {
    //        TimeToDelivery = 3,
    //        DeclaredValue = 100.00m
    //    };

    //    _companyRepositoryMock.Setup(x => x.GetByTokenKey(appToken, appKey)).Returns(company);

    //    _nexLogServiceMock.Setup(x => x.GetAuthenticationToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<NexLogAuthenticationRequest>()))
    //                       .Returns(tokenResponse);

    //    _nexLogServiceMock.Setup(x => x.GetCustomerPerson(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), "G3", "pt-BR"))
    //                      .Returns(customerToken);

    //    _nexLogServiceMock.Setup(x => x.QuotationRequest(It.IsAny<QuotationRequest>(), tokenResponse))
    //                      .Returns(quotationResponse);

    //    // Act
    //    var response = _calculateService.Calculate(calculateRequest, appToken, appKey);

    //    // Assert
    //    Assert.NotNull(response);
    //    Assert.True(response.Success);
    //    Assert.Equal("Cálculo realizado com sucesso.", response.Message);
    //}

    //[Fact]
    //public void Calculate_ShouldReturnErrorResponse_WhenCompanyNotFound()
    //{
    //    // Arrange
    //    var calculateRequest = new CalculateRequest
    //    {
    //        Items = new List<CalculateItem> { new CalculateItem { Weight = 1 } },
    //        Zipcode = "12345678",
    //        Amount = 100
    //    };

    //    string appToken = "invalidAppToken";
    //    string appKey = "invalidAppKey";

    //    _companyRepositoryMock.Setup(x => x.GetByTokenKey(appToken, appKey)).Returns((Company)null);

    //    // Act
    //    var response = _calculateService.Calculate(calculateRequest, appToken, appKey);

    //    // Assert
    //    Assert.NotNull(response);
    //    Assert.False(response.Success);
    //    Assert.Equal("Company não encontrada.", response.Message);
    //}
}
