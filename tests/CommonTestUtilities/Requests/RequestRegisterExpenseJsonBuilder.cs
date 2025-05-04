using Bogus;
using Nascente.Communication.Enums;
using Nascente.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.Amount, faker => faker.Commerce.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>());
    }
}
