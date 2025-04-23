﻿using Microsoft.AspNetCore.Mvc;
using Nascente.Application.UseCases.Expenses.Register;
using Nascente.Communication.Requests;
using Nascente.Communication.Responses;

namespace Nascente.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Register( [FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = ex.Message,
            }; 

            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = "unknowm error"
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
