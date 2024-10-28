using Application.UseCase.CreditCard;
using CreditCardApi.Base;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class CreditProposalController : ApiControllerBase
{
    //endpoint POST api/Credit/RequestCreditProposal
    [HttpPost("RequestCreditProposal")]
    public async Task<ActionResult> RequestCreditProposal(RequestCreditProposalRequest request)
    {
        var response = await Mediator.Send(request);

        if (response.HasError)
            return BadRequest(response);

        return Ok();
    }   
}