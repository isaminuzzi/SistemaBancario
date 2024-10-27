using Domain.Common.Response;
using Domain.Dto.User;

namespace Application.UseCase.User.Create;

public class CreateUserResponse : ResponseBase<CreateUserOutModel>
{
    public CreateUserResponse()
    {
        Data = new CreateUserOutModel();
    }
}