using Domain.Dto.CreditCard.PreRequestCreditCard.Input;
using MediatR;

namespace Application.UseCase.CreditCard;

public class RequestCreditProposalRequest : IRequest<RequestCreditProposalResponse>
{
    public SendPreRequestCreditProposalInModel Data { get; set; } = new();
}