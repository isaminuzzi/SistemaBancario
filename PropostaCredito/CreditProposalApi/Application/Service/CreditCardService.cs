using Application.Common;
using Domain;
using Domain.Dto.CreditCard;
using Domain.Dto.CreditCard.PreRequestCreditCard.Input;
using Domain.Dto.CreditCard.PreRequestCreditCard.Output;
using Domain.Dto.CreditCard.RequestCreditCard.Ouput;
using Domain.Enum;
using Domain.Interface.RabbitMq;
using Domain.Interface.Repository;
using Domain.Interface.Service;

namespace Application.Service;

public class CreditCardService (IMessage message, 
                                ICreditProposalRepository creditProposalRepository) : ICreditCardService
{
    
    public async Task<PreRequestCreditProposalOutModel> PreRequestCreditProposalAsync(SendPreRequestCreditProposalInModel model)
    {
        //validações do modelo
        model.CheckIfModelIsValid();

        var newSendToRequest = new SendToPreRequestCreditProposalInModel
        {
            RequestCreditCardProposalId = Guid.NewGuid(),
            Agency = model.Agency,
            Account = model.Account,
            UserCpf = model.UserCpf
        };
        
        //envio da mensagem para a fila
        await message.SendAsync(newSendToRequest);

        //retorno do Id da solicitação
        return new PreRequestCreditProposalOutModel
        {
            RequestCreditCardId = newSendToRequest.RequestCreditCardProposalId
        };
    }

    public async Task<RequestCreditProposalOutModel> RequestCreditProposalAsync(RequestCreditProposalInModel model)
    {
        //validações do modelo
        model.CheckIfModelIsValid();
        
        //validações do externa do cliente - Ex: Serasa
        //validações do cliente - Ex: Score
        
        //caso o usuário tenha sido aprovado


        var creditProposal = new CreditProposalEntity
        {
            Agency = model.Agency,
            Account = model.Account,
            UserId = new Guid(), //Id do usuário,
            Limit = 1000, //definição do limite de acordo com a análise de crédito,
            Status = CreditProposalStatusEnum.Approved, // status da proposta,
            InterestRate = 0.5, // taxa de juros,
        };

        await creditProposalRepository.AddAsync(creditProposal);
        
        return new RequestCreditProposalOutModel
        {
            CreditProposal = creditProposal
        };
    }
}