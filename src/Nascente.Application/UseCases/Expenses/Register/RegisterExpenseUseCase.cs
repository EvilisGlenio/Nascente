using Nascente.Communication.Enums;
using Nascente.Communication.Requests;
using Nascente.Communication.Responses;

namespace Nascente.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisterExpenseJson
        {
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            PaymentType = request.PaymentType,
            Date = request.Date
        };
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("Title cannot be empty!");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero!");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (!paymentTypeIsValid)
        {
            throw new ArgumentException("Invalid payment type");
        }

        var dateTime = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (dateTime <= 0)
        {
            throw new ArgumentException("Date cannot be in the future!");
        }
    }
}
