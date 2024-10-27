using Domain.Dto.CreditCard;
using Domain.Dto.CreditCard.PreRequestCreditCard.Input;
using Domain.Dto.CreditCard.PreRequestCreditCard.Output;
using Domain.Dto.CreditCard.RequestCreditCard.Ouput;

namespace Domain.Interface.Service;

public interface ICreditCardService
{
    Task<PreRequestCreditCardOutModel> PreRequestCreditCardAsync(SendPreRequestCreditCardInModel model);
    Task<RequestCreditCardOutModel> RequestCreditCardAsync(RequestCreditCardInModel model);
}