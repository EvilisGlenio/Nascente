using CommonTestUtilities.Requests;
using Nascente.Application.UseCases.Expenses.Register;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);

    }
}
