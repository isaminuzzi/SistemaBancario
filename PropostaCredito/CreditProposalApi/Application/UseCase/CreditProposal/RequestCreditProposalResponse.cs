using Domain.Common.Response;
using Domain.Dto.CreditCard.PreRequestCreditCard.Output;
using Domain.Dto.CreditCard.RequestCreditCard.Ouput;
using MassTransit;

namespace Application.UseCase.CreditCard;

public class RequestCreditProposalResponse : ResponseBase<PreRequestCreditProposalOutModel>
{
    public RequestCreditProposalResponse()
    {
        Data = new PreRequestCreditProposalOutModel();
    }
}