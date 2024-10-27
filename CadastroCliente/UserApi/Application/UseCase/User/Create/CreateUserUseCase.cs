using Domain.Interface.Service;
using MediatR;

namespace Application.UseCase.User.Create;

public class CreateUserUseCase(IUserService userService) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateUserResponse();

        try
        {
            response.Data = await userService.CreateUserAsync(request.Data);
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