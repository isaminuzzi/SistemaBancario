using Domain.Interface.Service;
using MediatR;

namespace Application.UseCase.CreditCard;

public class RequestCreditCardUseCase (ICreditCardService creditCardService): IRequestHandler<RequestCreditCardRequest, RequestCreditCardResponse>
{
    public async  Task<RequestCreditCardResponse> Handle(RequestCreditCardRequest request, CancellationToken cancellationToken)
    {
        var response = new RequestCreditCardResponse();
        
        try
        {
            response.Data = await creditCardService.PreRequestCreditCardAsync(request.Data);
            
            return response;
        }
        catch (Exception ex)
        {
            response.Data = null;
            response.HasError = true;
            response.Error = ex.Message;
            return response;
        }
    }
}