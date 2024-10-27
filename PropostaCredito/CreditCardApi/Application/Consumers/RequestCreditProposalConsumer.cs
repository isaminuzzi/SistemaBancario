using AutoMapper;
using Domain.Dto.CreditCard;
using Domain.Interface.Service;
using MassTransit;

namespace Application.Consumers;

public class RequestCreditProposalConsumer(ICreditCardService creditCardService,  IMapper mapper) : IConsumer<SendToPreRequestCreditProposalInModel>
{
   
    public async Task Consume(ConsumeContext<SendToPreRequestCreditProposalInModel> context)
    {
        try
        {
            //mapeia a mensagem para o modelo de entrada
            
            var model = mapper.Map<RequestCreditProposalInModel>(context.Message);
            
            //chama o serviço
            await creditCardService.RequestCreditProposalAsync(model);
        }
        catch (Exception ex)
        {
            // Reenvio de mensagem
            await context.Redeliver(TimeSpan.Zero);
        }
    }
}