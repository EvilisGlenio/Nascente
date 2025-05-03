using Nascente.Application.UseCases.Expenses.Register;
using Nascente.Communication.Requests;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Title = "Title",
            Description = "Description",
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            PaymentType = Nascente.Communication.Enums.PaymentType.Cash

        };

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);

    }
}
