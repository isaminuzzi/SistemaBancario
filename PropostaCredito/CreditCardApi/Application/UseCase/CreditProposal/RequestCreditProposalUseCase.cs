using Domain.Interface.Service;
using MediatR;

namespace Application.UseCase.CreditCard;

public class RequestCreditProposalUseCase (ICreditCardService creditCardService): IRequestHandler<RequestCreditProposalRequest, RequestCreditProposalResponse>
{
    public async  Task<RequestCreditProposalResponse> Handle(RequestCreditProposalRequest request, CancellationToken cancellationToken)
    {
        var response = new RequestCreditProposalResponse();
        
        try
        {
            response.Data = await creditCardService.PreRequestCreditProposalAsync(request.Data);
            
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