using Microsoft.AspNetCore.Mvc;
using Nascente.Application.UseCases.Expenses.Register;
using Nascente.Communication.Requests;

namespace Nascente.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Register( [FromBody] RequestRegisterExpenseJson request)
    {
        var useCase = new RegisterExpenseUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
