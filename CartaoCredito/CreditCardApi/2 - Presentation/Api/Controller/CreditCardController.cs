using Application.UseCase.CreditCard;
using CreditCardApi.Base;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class CreditCardController : ApiControllerBase
{
    //endpoint POST api/CreditCard/RequestCreditCard
    [HttpPost("RequestCreditCard")]
    public async Task<ActionResult> RequestCreditCard(RequestCreditCardRequest request)
    {
        var response = await Mediator.Send(request);

        if (response.HasError)
            return BadRequest(response);

        return Ok();
    }   
}