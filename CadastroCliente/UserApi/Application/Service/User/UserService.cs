using System.Reflection;
using Application.Common;
using Domain;
using Domain.Dto.User;
using Domain.Interface.Repository;
using Domain.Interface.Service;

namespace Application.Service.User;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<CreateUserOutModel> CreateUserAsync(CreateUserInModel model)
    {
        model.CheckIfModelIsValid();
        
        var userExists = await _userRepository.ExistsByCpfAsync(model.Cpf);
        
        if (userExists)
        {
            throw new Exception("User already exists");
        }
        
        var userEntity = new UserEntity
        {
            Name = model.Name,
            Cpf = model.Cpf,
            Balance = 0 
        };
        
        var user = await _userRepository.AddAsync(userEntity);

        return new CreateUserOutModel()
        {
            Id = user.Id,
            Name = user.Name,
            Cpf = user.Cpf,
            Balance = user.Balance
        };
    }
}