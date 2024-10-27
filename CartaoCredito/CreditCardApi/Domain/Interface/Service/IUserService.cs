using Domain.Dto.User;

namespace Domain.Interface.Service;

public interface IUserService
{
    Task<CreateUserOutModel> CreateUserAsync(CreateUserInModel user);
}