using Domain.Dto.CreditCard.PreRequestCreditCard.Input;
using MediatR;

namespace Application.UseCase.CreditCard;

public class RequestCreditCardRequest : IRequest<RequestCreditCardResponse>
{
    public SendPreRequestCreditCardInModel Data { get; set; } = new();
}