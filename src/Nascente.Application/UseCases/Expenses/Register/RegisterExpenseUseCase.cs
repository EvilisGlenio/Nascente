using Nascente.Communication.Requests;
using Nascente.Communication.Responses;
using Nascente.Exception.ExceptionsBase;

namespace Nascente.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
