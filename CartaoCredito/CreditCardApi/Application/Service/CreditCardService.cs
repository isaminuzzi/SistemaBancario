using Application.Common;
using Domain;
using Domain.Dto.CreditCard;
using Domain.Dto.CreditCard.PreRequestCreditCard.Input;
using Domain.Dto.CreditCard.PreRequestCreditCard.Output;
using Domain.Dto.CreditCard.RequestCreditCard.Ouput;
using Domain.Interface.RabbitMq;
using Domain.Interface.Repository;
using Domain.Interface.Service;

namespace Application.Service;

public class CreditCardService (IMessage message, 
                                ICreditCardRepository creditCardRepository) : ICreditCardService
{
    
    public async Task<PreRequestCreditCardOutModel> PreRequestCreditCardAsync(SendPreRequestCreditCardInModel model)
    {
        //validações do modelo
        model.CheckIfModelIsValid();

        var newSendToRequest = new SendToRequestCreditCardInModel
        {
            RequestCreditCardId = Guid.NewGuid(),
            Agency = model.Agency,
            Account = model.Account,
            CardHolderName = model.CardHolderName,
            CardNumber = model.CardNumber,
            ExpirationDate = model.ExpirationDate,
            CVV = model.CVV,
            Quantity = model.Quantity,
            IsVirtual = model.IsVirtual
        };
        
        //envio da mensagem para a fila
        await message.SendAsync(newSendToRequest);

        //retorno do Id da solicitação
        return new PreRequestCreditCardOutModel
        {
            RequestCreditCardId = newSendToRequest.RequestCreditCardId
        };
    }

    public async Task<RequestCreditCardOutModel> RequestCreditCardAsync(RequestCreditCardInModel model)
    {
        //validações do modelo
        model.CheckIfModelIsValid();
        
        //validações do externa do cliente - Ex: Serasa
       
        
        //cria o cartão
        var creditCard = new CreditCardEntity
        {
            Id = model.RequestCreditCardId,
            Agency = model.Agency,
            Account = model.Account,
            CardHolderName = model.CardHolderName,
            CardNumber = model.CardNumber,
            ExpirationDate = model.ExpirationDate,
            CVV = model.CVV,
            Quantity = model.Quantity,
            IsVirtual = model.IsVirtual,
            IsBlocked = false
        };

        await creditCardRepository.AddAsync(creditCard);
        
        return new RequestCreditCardOutModel
        {
            CreditCard = creditCard
        };
    }
}