using AutoMapper;
using Domain.Dto.CreditCard;
using Domain.Interface.Service;
using MassTransit;

namespace Application.Consumers;

public class RequestCreditCardConsumer(ICreditCardService creditCardService,  IMapper mapper) : IConsumer<SendToRequestCreditCardInModel>
{
   
    public async Task Consume(ConsumeContext<SendToRequestCreditCardInModel> context)
    {
        try
        {
            //mapeia a mensagem para o modelo de entrada
            
            var model = mapper.Map<RequestCreditCardInModel>(context.Message);
            
            //chama o serviço
            await creditCardService.RequestCreditCardAsync(model);
        }
        catch (Exception ex)
        {
            // Reenvio de mensagem
            await context.Redeliver(TimeSpan.Zero);
        }
    }
}